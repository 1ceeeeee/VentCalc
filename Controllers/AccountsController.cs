﻿using System;
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

        private readonly VentCalcDbContext _context;

        public AccountsController(IUnitOfWork uow, IMapper mapper, UserManager<AppUser> userManager, VentCalcDbContext context) {
            this._mapper = mapper;
            this._unitOfWork = uow;
            this._userManager = userManager;
            this._context = context;
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
        public async Task<IEnumerable<PortalUser>> GetAll(){            
            var users = await _unitOfWork.Repository<PortalUser>().GetEnumerableIcludeMultipleAsync(x => x.Identity);
            return users;
        }

    }
}