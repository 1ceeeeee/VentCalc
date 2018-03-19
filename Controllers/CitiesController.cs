using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Persistence;

namespace VentCalc.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly VentCalcDbContext context;
        private readonly IMapper mapper;
        public CitiesController(VentCalcDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CityResource>> GetAll()
        {
            var cities = await context.Cities.ToListAsync();
            
            return mapper.Map<List<City>, List<CityResource>>(cities);
        }
    }
}