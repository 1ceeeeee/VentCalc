using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VentCalc.Models;
using VentCalc.Persistence;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    public abstract class BaseController : Controller {

        public readonly IMapper Mapper;
        public IUnitOfWork UnitOfWork;
        public BaseController(IMapper mapper, IUnitOfWork uow)
        {
            this.Mapper = mapper;
            this.UnitOfWork = uow;
        }

        public async System.Threading.Tasks.Task<int> GetCurrentUserIdAsync(string id){
            var user = await UnitOfWork.Repository<PortalUser>().GetSingleIcludeMultipleAsync(x => x.IdentityId == id, x => x.Identity); 
            return user?.Id ?? 0;
        }

    }
}