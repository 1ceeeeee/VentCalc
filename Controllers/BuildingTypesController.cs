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

namespace VentCalc.Controllers
{
    [Route("api/[controller]")]
    public class BuildingTypesController : BaseController
    {
        public BuildingTypesController(IMapper mapper, IUnitOfWork uow) : base(mapper, uow) {
        }

        [HttpGet]
        public async Task<IEnumerable<BuildingTypeResource>> ReadAll()
        {
            var buildingTypes = await UnitOfWork.Repository<BuildingType>().GetEnumerableAsync();
            return Mapper.Map<List<BuildingType>, List<BuildingTypeResource>>(buildingTypes.ToList());
        }

        [HttpGet]
        [Route("~/api/BuildingKinds/{buildingKindId:int}/BuildingTypes")]
        public async Task<IEnumerable<BuildingTypeResource>> ReadBuildingTypesByBuildingKind(int buildingKindId)
        {
            var buildingTypes = await UnitOfWork.Repository<BuildingType>().GetEnumerableIcludeMultipleAsync(
                    x => x.DeleteUsertId == null, 
                    x => x.BuildingPurpose
                );
           
            var buildingTypesByBuildingKind = buildingTypes.Where(
                bp => bp.BuildingPurpose.BuildingKindId == buildingKindId
            );

            return Mapper.Map<List<BuildingType>, List<BuildingTypeResource>>(buildingTypesByBuildingKind.ToList());
            
            // return await context.BuildingTypes
            //     .Include(bt => bt.BuildingPurpose)
            //     .Where(bp => bp.BuildingPurpose.BuildingKindId == buildingKindId)
            //     .ToListAsync();

            // var buildingTypes = await repository.GetBuildingTypesByBuildingKindint(buildingKindId);

            // return mapper.Map<List<BuildingType>, List<BuildingTypeResource>>(buildingTypes);
        }

    }
}