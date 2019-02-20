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

        public BaseController(IMapper mapper, IUnitOfWork uow) {
            this.Mapper = mapper;
            this.UnitOfWork = uow;
        }

    }
}