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
    public class BuildingPurposesController : BaseController {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        public BuildingPurposesController(IUnitOfWork uow, IMapper mapper) : base(mapper, uow) {

        }

        [HttpGet]
        public async Task<IEnumerable<BuildingPurposeResource>> GetAll() {
            var buildingPurposes = await UnitOfWork.Repository<BuildingPurpose>().GetEnumerableAsync(); // context.BuildingPurposes.ToListAsync();
            return mapper.Map<List<BuildingPurpose>, List<BuildingPurposeResource>>(buildingPurposes.ToList());
        }
    }
}