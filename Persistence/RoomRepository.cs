using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VentCalc.Models;
using VentCalc.Persistence;

namespace VentCalc.Persistence
{
    public class RoomRepository : IRoomRepository
    {
        private readonly VentCalcDbContext context;
        public RoomRepository(VentCalcDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Room>> GetAll() 
        {
            return await context.Rooms.ToListAsync();
        }        

        public async Task<Room> GetSingle(int id)
        {
            return await context.Rooms
                .Include(r => r.City)
                .Include(r => r.BuildingType)
                .Include(r => r.RoomType)
                .SingleOrDefaultAsync(r => r.Id == id);
        }        

        public Room CreateRoom(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
            return room;
        }
    }
}