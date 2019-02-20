using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using VentCalc.Models;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "ApiUser")]
    public abstract class AuthorizeBaseController : BaseController {
        protected readonly User CurrentUser;
        protected readonly IHttpContextAccessor HttpContextAccessor;

        // public AuthorizeBaseController(IMapper mapper, IUnitOfWork uow) : base(mapper, uow) { }

        protected AuthorizeBaseController(IMapper mapper, IUnitOfWork uow, IHttpContextAccessor httpContextAccessor) : base(mapper, uow) {
            HttpContextAccessor = httpContextAccessor; 
            CurrentUser = GetCurrentUser();
        }

        private User GetCurrentUser() {
            var login = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return UnitOfWork.Repository<User>().GetEnumerable(x => x.Login == login).FirstOrDefault();
        }
    }
}