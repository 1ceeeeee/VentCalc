using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VentCalc.Models;
using VentCalc.Persistence;

namespace VentCalc.Persistence
{
    public class BuildingTypeRepository : IBuildingTypeRepository
    {
        private readonly VentCalcDbContext context;
        public BuildingTypeRepository(VentCalcDbContext context)
        {
            this.context = context;

        }

        public async Task<List<BuildingType>> GetAll() 
        {
            return await context.BuildingTypes.ToListAsync();
        }

        public async Task<List<BuildingType>> GetBuildingTypesByBuildingKindint(int buildingKindId) 
        {
            return await context.BuildingTypes
                .Include(bt => bt.BuildingPurpose)
                .Where(bp => bp.BuildingPurpose.BuildingKindId == buildingKindId)
                .ToListAsync();
        }
        
    }
}