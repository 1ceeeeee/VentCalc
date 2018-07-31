using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    public class BaseController : Controller {
        public readonly IMapper Mapper;
        public IUnitOfWork UnitOfWork;

        public BaseController(IMapper mapper, IUnitOfWork uow)
        {
            this.Mapper = mapper;
            this.UnitOfWork = uow;
        }
    }
}