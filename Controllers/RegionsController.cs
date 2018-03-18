using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Persistence;

namespace VentCalc.Controllers
{
    [Route("api/[controller]")]
    public class RegionsController : Controller
    {
        private readonly VentCalcDbContext context;
        private readonly IMapper mapper;
        public RegionsController(VentCalcDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }
        [HttpGet]
        public async Task<IEnumerable<RegionResource>> GetAll()
        {
            var regions = await context.Regions.Include(m => m.Cities).ToListAsync();
            
            return mapper.Map<List<Region>, List<RegionResource>>(regions);
        }
    }
}