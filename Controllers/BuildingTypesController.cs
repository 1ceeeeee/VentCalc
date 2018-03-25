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
        private readonly IMapper _mapper;
        private readonly IBuildingTypeRepository _repository;
        private readonly VentCalcDbContext _context;
        public BuildingTypesController(IMapper mapper, VentCalcDbContext context, IBuildingTypeRepository repository)
        {
            this._mapper = mapper;
            this._context = context;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<BuildingTypeResource>> Get()
        {
            var buildingTypes = await _repository.GetAll();

            return _mapper.Map<List<BuildingType>, List<BuildingTypeResource>>(buildingTypes);
        }

        [HttpGet]
       // [Route("{buildingKindId}")]
       [Route("~/api/BuildingKinds/{buildingKindId:int}/BuildingTypes")]
        public async Task<IEnumerable<BuildingTypeResource>> GetBuildingTypesByBuildingKind(int buildingKindId)
        {
            var buildingTypes = await _repository.GetBuildingTypesByBuildingKindint(buildingKindId);

            return _mapper.Map<List<BuildingType>, List<BuildingTypeResource>>(buildingTypes);
        }

    }
}