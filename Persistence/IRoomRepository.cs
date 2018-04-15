using System.Collections.Generic;
using System.Threading.Tasks;
using VentCalc.Controllers.Resources;
using VentCalc.Models;

namespace VentCalc.Persistence
{
    public interface IRoomRepository
    {
         Task<List<Room>> GetAll();
         Task<Room> GetSingle(int id);
         Room CreateRoom(Room room);

    }
}