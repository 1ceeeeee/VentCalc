using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentCalc.Models;
using VentCalc.Persistence;

namespace VentCalc.Controllers
{
    public class RegionsController : Controller
    {
        private readonly VentCalcDbContext context;
        public RegionsController(VentCalcDbContext context)
        {
            this.context = context;

        }
        [HttpGet("api/regions")]
        public async Task<IEnumerable<Region>> GetRegions() 
        {
            return await context.Regions.Include(m => m.Cities).ToListAsync();
        }
    }
}