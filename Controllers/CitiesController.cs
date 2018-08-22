using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Persistence;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    // [Authorize(AuthenticationSchemes = "Bearer", Policy = "ApiUser")]
    [Route("api/[controller]")]
    public class CitiesController : Controller {
        
        private readonly IMapper Mapper;
        private IUnitOfWork UnitOfWork;
        public CitiesController(IUnitOfWork uow, IMapper mapper) {
            this.Mapper = mapper;
            this.UnitOfWork = uow;
        }

        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetAll()
        {            
            var cities = await UnitOfWork.Repository<City>().GetEnumerableAsync();

            // var t = UnitOfWork.Repository<PortalUser>().GetEnumerable(x => x.IdentityId == "12312312312312").FirstOrDefault();

            return Mapper.Map<List<City>, List<CityResource>>(cities.ToList());
        }

    }
}