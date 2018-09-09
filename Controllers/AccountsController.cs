using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Persistence;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    [Route("api/[controller]")]
    public class AccountsController : Controller {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountsController(IUnitOfWork uow, IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) {
            this._mapper = mapper;
            this._unitOfWork = uow;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PortalUserResource portalUserResource) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userIdentity = _mapper.Map<PortalUserResource, AppUser>(portalUserResource);
            var result = await _userManager.CreateAsync(userIdentity, portalUserResource.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(result.Errors);

            await _unitOfWork.Repository<PortalUser>().AddAsync(new PortalUser() {
                IdentityId = userIdentity.Id
            });

            _unitOfWork.Commit();

            return new OkObjectResult("Account created.");
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

        [HttpGet]
        public async Task<IEnumerable<PortalUserResource>> GetAll() {
            var users = await _unitOfWork.Repository<PortalUser>().GetEnumerableIcludeMultipleAsync(x => x.Identity);

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
            //TODO: отрефакторить, привести к нормальному виду.
            var user = await _unitOfWork.Repository<PortalUser>().GetEnumerableIcludeMultipleAsync(x => x.IdentityId == id, x => x.Identity);
            var selectedUser = user.SingleOrDefault();
            var res = new PortalUserWithRolesResource();
            if (selectedUser != null) {
                res.IdentityId = selectedUser.IdentityId;
                res.UserRoles = await _userManager.GetRolesAsync(selectedUser.Identity);
                res.AllRoles = _roleManager.Roles.Select(x => x.Name).ToList();
            }
            return res;
        }

        [HttpPost("editRoles")]
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