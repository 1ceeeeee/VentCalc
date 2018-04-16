using System.Collections.Generic;
using System.Threading.Tasks;
using VentCalc.Controllers.Resources;
using VentCalc.Models;

namespace VentCalc.Persistence
{
    public interface IRoomRepository
    {
         Task<List<Room>> ReadAll();
         Task<List<Room>> ReadAll(int projectId);
         Task<Room> ReadSingle(int id);
         Task<Room> Create(Room room);
         Task<Room> Update(Room room);
         void Delete(int id);

    }
}