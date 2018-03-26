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
                    //.ThenInclude(vf => vf.BuildingType)
                .Include(r => r.BuildingType)
                    //.ThenInclude(m => m.Make)
                .Include(r => r.RoomType)
                .SingleOrDefaultAsync(r => r.Id == id);
        }        
    }
}