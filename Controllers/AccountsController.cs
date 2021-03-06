﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Persistence;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    [Route("api/[controller]")]

    public class AccountsController : BaseController {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsController(IUnitOfWork uow, IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) : base(mapper, uow) {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserResource userResource) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (string.IsNullOrEmpty(userResource.Password))
                return BadRequest("Password is empty");

            try {
                var user = Mapper.Map<UserResource, User>(userResource);
                user.SetPasswordHash(userResource.Password);
                await UnitOfWork.Repository<User>().AddAsync(user);
                UnitOfWork.Commit();
            } catch (Exception e) {
                return BadRequest($"User creation fails. error: {e.StackTrace}");
            }

            return new OkObjectResult("Account created.");
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "ApiUser", Roles = "Администратор")]
        public async Task<IActionResult> Delete(string id) {

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return BadRequest(("user_delete_failure", "Пользователь с таким ID не найден"));

            var pUsers = await UnitOfWork.Repository<PortalUser>().GetEnumerableAsync(x => x.IdentityId == id);
            var pUser = pUsers.SingleOrDefault();
            if (pUser != null) {
                UnitOfWork.Repository<PortalUser>().Delete(pUser);
                await _userManager.DeleteAsync(user);
            }

            return new OkObjectResult("User deleted");
        }

        [HttpPost("changepwd")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordResource changePwd) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByIdAsync(changePwd.Id);

            if (user == null) {
                return BadRequest(("find_user_failure", "Не удалость найти пользователя.", ModelState));
            }

            var result = await _userManager.ChangePasswordAsync(user, changePwd.OldPassword, changePwd.NewPassword);

            if (result.Succeeded) {
                return new OkObjectResult("Password changed.");
            } else {
                if (result.Errors.Any())
                    return BadRequest(("change_password_failure", "Старый пароль введен не верно"));
                // return BadRequest(result.Errors.ToArray());              
            }

            return new OkObjectResult("Password changed.");

        }

        [HttpPost("changepwdhash")]
        // [Authorize(AuthenticationSchemes = "Bearer", Policy = "ApiUser", Roles = "Администратор")]
        public async Task<IActionResult> ChangePasswordHash([FromBody] ChangePasswordResource pwd) {

            var user = await _userManager.FindByIdAsync(pwd.Id);

            if (user == null) {
                return BadRequest(("find_user_failure", "Не удалость найти пользователя.", ModelState));
            }

            var _passwordValidator =
                HttpContext.RequestServices.GetService(typeof(IPasswordValidator<AppUser>)) as IPasswordValidator<AppUser>;
            var _passwordHasher =
                HttpContext.RequestServices.GetService(typeof(IPasswordHasher<AppUser>)) as IPasswordHasher<AppUser>;

            IdentityResult result =
                await _passwordValidator.ValidateAsync(_userManager, user, pwd.NewPassword);

            if (result.Succeeded) {
                user.PasswordHash = _passwordHasher.HashPassword(user, pwd.NewPassword);
                await _userManager.UpdateAsync(user);
                return new OkObjectResult("Password changed.");
            } else {
                if (result.Errors.Any())
                    return BadRequest(("change_password_failure", result.Errors.ToArray()));
            }

            return new OkObjectResult("Password changed.");
        }

        // [HttpGet("test")]
        // [Authorize(AuthenticationSchemes = "Bearer", Policy = "ApiUser", Roles = "Администратор")]
        // public JsonResult Test() {

        //     // var u = User.Identity.Name;
        //     var user = HttpContext.Request.Headers; //["Authorization"];
        //     return new JsonResult(user);
        // }

        [HttpGet]
        public async Task<IEnumerable<PortalUserResource>> GetAll() {
            var users = await UnitOfWork.Repository<PortalUser>().GetEnumerableIcludeMultipleAsync(x => x.Identity);

            var portalUsers = new List<PortalUserResource>();

            foreach (var user in users) {
                portalUsers.Add(new PortalUserResource() {
                    Id = user.Id,
                        FirstName = user.Identity?.FirstName,
                        SecondName = user.Identity?.SecondName,
                        LastName = user.Identity?.LastName,
                        UserName = user.Identity?.UserName,
                        Email = user.Identity?.Email,
                        IdentityId = user.IdentityId
                });
            }
            return portalUsers;
        }

        [HttpGet("{id}")]
        public async Task<PortalUserWithRolesResource> GetById(string id) {
            var user = await UnitOfWork.Repository<PortalUser>().GetSingleIcludeMultipleAsync(x => x.IdentityId == id, x => x.Identity);
            var res = new PortalUserWithRolesResource();
            if (user != null) {
                res.IdentityId = user.IdentityId;
                res.UserRoles = await _userManager.GetRolesAsync(user.Identity);
                res.AllRoles = _roleManager.Roles.Select(x => x.Name).ToList();
                res.FirstName = user.Identity.FirstName;
                res.SecondName = user.Identity.SecondName;
                res.LastName = user.Identity.LastName;
            }
            return res;
        }

        [HttpPost("editRoles")]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "ApiUser", Roles = "Администратор")]
        public async Task<IActionResult> EditUserRoles([FromBody] PortalUserWithRolesResource userResource) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByIdAsync(userResource.IdentityId);

            if (user == null) return NotFound();

            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            var addedRoles = userResource.UserRoles?.Except(userRoles);
            var removedRoles = userRoles.Except(userResource.UserRoles);

            await _userManager.AddToRolesAsync(user, addedRoles);
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            return Ok("Success");
        }

    }
}