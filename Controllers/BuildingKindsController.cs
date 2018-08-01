using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Persistence;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    [Route("api/[controller]")]
    public class BuildingKindsController : Controller {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper mapper;
        public BuildingKindsController(IUnitOfWork uow, IMapper mapper) {
            this.mapper = mapper;
            this.UnitOfWork = uow;
        }

        [HttpGet]
        public async Task<IEnumerable<BuildingKindResource>> GetAll() {
            var buildingKinds = await UnitOfWork.Repository<BuildingKind>().GetEnumerableAsync(); //await context.BuildingKinds.ToListAsync();

            return mapper.Map<List<BuildingKind>, List<BuildingKindResource>>(buildingKinds.ToList());
        }
    }
}