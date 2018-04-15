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

        public async Task<List<Room>> ReadAll() 
        {
            return await context.Rooms.ToListAsync();
        }        

        public async Task<Room> ReadSingle(int id)
        {
            return await context.Rooms
                .Include(r => r.City)
                .Include(r => r.BuildingType)
                .Include(r => r.RoomType)
                .SingleOrDefaultAsync(r => r.Id == id);
        }        

        public async Task<Room> CreateRoom(Room room)
        {   
            context.Rooms.Add(room);
            context.SaveChanges();
            return await context.Rooms.FirstOrDefaultAsync(r => r.Id == room.Id);
        }

        public async Task<Room> UpdateRoom(Room room)
        {
            context.Rooms.Update(room);
            context.SaveChanges();
            return await context.Rooms.FirstOrDefaultAsync(r => r.Id == room.Id);
        }

        public void DeleteRoom(int id)
        {
            var room = context.Rooms.FirstOrDefault(r => r.Id == id);
            context.Rooms.Remove(room);
            context.SaveChanges();
        }
    }
}