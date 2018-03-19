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
    public class BuildingTypesController : Controller
    {
        private readonly VentCalcDbContext context;
        private readonly IMapper mapper;
        public BuildingTypesController(VentCalcDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        
        [HttpGet]
        public async Task<IEnumerable<BuildingTypeResource>> GetAll()
        {
            var buildingTypes = await context.BuildingTypes.ToListAsync();
            
            return mapper.Map<List<BuildingType>, List<BuildingTypeResource>>(buildingTypes);
        }
    }
}