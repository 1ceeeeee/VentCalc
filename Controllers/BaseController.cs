using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VentCalc.Models;
using VentCalc.Persistence;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    public abstract class BaseController : Controller {

        public readonly IMapper Mapper;
        public IUnitOfWork UnitOfWork;
        protected readonly IHttpContextAccessor HttpContextAccessor;
        protected readonly User CurrentUser;
        public BaseController(IMapper mapper, IUnitOfWork uow) {
            this.Mapper = mapper;
            this.UnitOfWork = uow;
        }

        public async System.Threading.Tasks.Task<int> GetCurrentUserIdAsync(string id) {
            var user = await UnitOfWork.Repository<PortalUser>().GetSingleIcludeMultipleAsync(x => x.IdentityId == id, x => x.Identity);
            return user?.Id ?? 0;
        }

        protected BaseController(IMapper mapper, IUnitOfWork uow, IHttpContextAccessor httpContextAccessor) {
            Mapper = mapper;
            UnitOfWork = uow;
            HttpContextAccessor = httpContextAccessor;
            CurrentUser = GetCurrentUser();
        }

        private User GetCurrentUser() {
            var login = HttpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return UnitOfWork.Repository<User>().GetEnumerable(x => x.Login == login).FirstOrDefault();
        }

    }
}