using System.Collections.Generic;
using System.Threading.Tasks;
using VentCalc.Controllers.Resources;
using VentCalc.Models;

namespace VentCalc.Persistence
{
    public interface IRoomRepository
    {
         Task<List<Room>> ReadAll();
         Task<Room> ReadSingle(int id);
         Task<Room> CreateRoom(Room room);
         Task<Room> UpdateRoom(Room room);
         void DeleteRoom(int id);

    }
}