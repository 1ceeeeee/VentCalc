using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Persistence;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    [Route("api/[controller]")]
    public class RegionsController : BaseController {
        public RegionsController(IUnitOfWork uow, IMapper mapper) : base(mapper, uow) { }

        [HttpGet]
        public async Task<IEnumerable<RegionResource>> GetAll() {
            var regions = await UnitOfWork.Repository<Region>()
            .GetEnumerableIcludeMultipleAsync(x => x.DeleteUsertId == null, i => i.Cities);  //context.Regions.Include(m => m.Cities).ToListAsync();
            return Mapper.Map<List<Region>, List<RegionResource>>(regions.ToList());
        }
    }
}