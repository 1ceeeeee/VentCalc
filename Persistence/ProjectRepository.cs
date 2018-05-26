using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VentCalc.Controllers.Resources;
using VentCalc.Models;

namespace VentCalc.Persistence
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly VentCalcDbContext context;
        public ProjectRepository(VentCalcDbContext context)
        {
            this.context = context;
        }

         public async Task<List<Project>> ReadAll()
         {
            return await context.Projects.ToListAsync();
         }

        public async Task<Project> ReadSingle(int id)
        {
            return await context.Projects
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> Create(Project project)
        {   
            context.Projects.Add(project);
            context.SaveChanges();
            return await context.Projects.FirstOrDefaultAsync(r => r.Id == project.Id);
        }

        public async Task<Project> Update(Project project)
        {
            context.Projects.Update(project);
            context.SaveChanges();
            return await context.Projects.FirstOrDefaultAsync(r => r.Id == project.Id);
        }

        public void Delete(int id)
        {
            var project = context.Projects.FirstOrDefault(r => r.Id == id);
            context.Projects.Remove(project);
            context.SaveChanges();
        }

        public AirExchangeProjectResource ReadAirExchange(int id)
        {

            var project = context.Projects
            .Include(p => p.Rooms)
                .ThenInclude(r => r.City)
            // .Include(p => p.Rooms)
            //     .ThenInclude(r => r.BuildingType)
            .Include(p => p.Rooms)
                .ThenInclude(r => r.RoomType)
            .Where(p => p.Id == id)
            .FirstOrDefault();

            var airExchangeRooms = new List<AirExchangeRoomResource>();

            foreach (var item in project.Rooms)
            {
                var area = (item.Area != null) ? item.Area : item.Length * item.Width;
                var volume = area * item.Height;
                airExchangeRooms.Add(new AirExchangeRoomResource() {
                        Id = item.Id,
                        RoomNumber = item.RoomNumber,
                        RoomName = item.RoomName,
                        TempIn = item.RoomType.TempIn,
                        Area = area,
                        Volume = volume,
                        PeopleAmount = item.PeopleAmount,
                        Inflow = item.RoomType.Inflow,
                        Exhaust = item.RoomType.Exhaust,
                        InflowCalc = volume * item.RoomType.Inflow,
                        ExhaustCalc = volume * item.RoomType.Exhaust  
                    }
                ); 
            }      

            var airExchangeProject = new AirExchangeProjectResource()
            {
                Id = project.Id,
                InflowTotal = airExchangeRooms.Sum(x => x.InflowCalc),
                ExhaustTotal = airExchangeRooms.Sum(x => x.ExhaustCalc),
                AirExchangeRooms = airExchangeRooms
            };

            return airExchangeProject;
        }


    }
}