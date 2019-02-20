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
    [Route("api/[controller]")]
    public class CitiesController : BaseController {
        public CitiesController(IUnitOfWork uow, IMapper mapper) : base(mapper, uow) { }

        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetAll() {
            var cities = await UnitOfWork.Repository<City>().GetEnumerableAsync();
            return Mapper.Map<List<City>, List<CityResource>>(cities.ToList());
        }

    }
}