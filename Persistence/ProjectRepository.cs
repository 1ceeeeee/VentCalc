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
        private readonly IRoomTypeValueRepository roomTypeValueRepository;

        public ProjectRepository(VentCalcDbContext context, IRoomTypeValueRepository roomTypeValueRepository)
        {
            this.context = context;
            this.roomTypeValueRepository = roomTypeValueRepository;
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
                .Where(p => p.Id == id)
                .FirstOrDefault();
            
            var airExchangeRooms = new List<AirExchangeRoomResource>();

            foreach (var item in project.Rooms)
            {
                var area = (item.Area != null) ? item.Area : item.Length * item.Width;
                var volume = area * item.Height;
                
                var roomTypeValue = roomTypeValueRepository.GetRoomTypeValue(project, item.RoomTypeId);

                airExchangeRooms.Add(new AirExchangeRoomResource() {

                        Id = item.Id,
                        RoomNumber = item.RoomNumber,
                        RoomName = item.RoomName,
                        TempIn = roomTypeValue.TempIn,
                        Area = area,
                        Volume = volume,
                        PeopleAmount = item.PeopleAmount,
                        // Inflow = item.RoomType.Inflow,
                        // Exhaust = item.RoomType.Exhaust,
                        InflowCalc = GetRoomInflowCalc(roomTypeValue, volume, item.PeopleAmount),
                        ExhaustCalc = GetRoomExhaustCalc(roomTypeValue, volume, item.PeopleAmount)
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

        public double? GetRoomInflowCalc (RoomTypeValue roomTypeValue, double? volume,int? peopleAmount)
        {
            double? inflowCalc = 0;

            if (roomTypeValue.Inflow != null)
            {
                inflowCalc = roomTypeValue.Inflow;
            }
            else if (roomTypeValue.InflowArea != null )
            {
                //TODO: добавить рассчет по площади
            }
            else if (roomTypeValue.InflowMultiply != null )
            {
                inflowCalc = roomTypeValue.InflowMultiply * volume;
            }
            else if (roomTypeValue.InflowPeople != null )
            {
                inflowCalc = roomTypeValue.InflowPeople * peopleAmount;
            }

            return inflowCalc;
        }

       public double? GetRoomExhaustCalc (RoomTypeValue roomTypeValue, double? volume,int? peopleAmount)
        {
            double? exhaustCalc = 0;

            if (roomTypeValue.Exhaust != null)
            {
                exhaustCalc = roomTypeValue.Exhaust;
            }
            else if (roomTypeValue.ExhaustArea != null )
            {
                //TODO: добавить рассчет по площади
            }
            else if (roomTypeValue.ExhaustMultiply != null )
            {
                exhaustCalc = roomTypeValue.ExhaustMultiply * volume;
            }
            else if (roomTypeValue.ExhaustPeople != null )
            {
                exhaustCalc = roomTypeValue.ExhaustPeople * peopleAmount;
            }

            return exhaustCalc;
        }

    }
}