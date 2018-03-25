using System.Collections.Generic;
using System.Threading.Tasks;
using VentCalc.Models;

namespace VentCalc.Persistence
{
    public interface IBuildingTypeRepository
    {
         Task<List<BuildingType>> GetAll(); 
         Task<List<BuildingType>> GetBuildingTypesByBuildingKindint(int buildingKindId);
    }
}