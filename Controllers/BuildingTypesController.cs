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
        private readonly IMapper mapper;
        private readonly IBuildingTypeRepository repository;
        private readonly VentCalcDbContext context;
        public BuildingTypesController(IMapper mapper, VentCalcDbContext context, IBuildingTypeRepository repository)
        {
            this.mapper = mapper;
            this.context = context;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<BuildingTypeResource>> Get()
        {
            var buildingTypes = await repository.GetAll();

            return mapper.Map<List<BuildingType>, List<BuildingTypeResource>>(buildingTypes);
        }

        [HttpGet]
        [Route("~/api/BuildingKinds/{buildingKindId:int}/BuildingTypes")]
        public async Task<IEnumerable<BuildingTypeResource>> GetBuildingTypesByBuildingKind(int buildingKindId)
        {
            var buildingTypes = await repository.GetBuildingTypesByBuildingKindint(buildingKindId);

            return mapper.Map<List<BuildingType>, List<BuildingTypeResource>>(buildingTypes);
        }

    }
}