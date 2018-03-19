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
    public class BuildingPurposesController : Controller
    {
        private readonly VentCalcDbContext context;
        private readonly IMapper mapper;
        public BuildingPurposesController(VentCalcDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;
        }
        
        [HttpGet]
        public async Task<IEnumerable<BuildingPurposeResource>> GetAll()
        {
            var buildingPurposes = await context.BuildingPurposes.ToListAsync();
            
            return mapper.Map<List<BuildingPurpose>, List<BuildingPurposeResource>>(buildingPurposes);
        }
    }
}