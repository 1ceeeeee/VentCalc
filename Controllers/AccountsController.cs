using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    [Route("api/[controller]")]
    public class AccountsController : Controller {

        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        
        public AccountsController(IUnitOfWork uow, IMapper mapper, UserManager<AppUser> userManager) {
            this._mapper = mapper;
            this._unitOfWork = uow;
            this._userManager = userManager;
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

            return new OkObjectResult("Account created");
        }

    }
}