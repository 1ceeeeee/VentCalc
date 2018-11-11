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
        
            var rooms = context.Rooms.Where(r => r.ProjectId == id).ToList();

            //Вычисление общей площади квартиры
            var areaTotalAmount = rooms.Sum(r => (r.Area != null) ? r.Area : r.Length * r.Width);

            //Вычисление общего объема квартиры
            var volumeTotalAmount = rooms.Sum(r => (r.Area * r.Height != null) ? r.Area * r.Height : r.Length * r.Width * r.Height);

            //Вычисление общего кол-ва людей
            var peopleTotalAmount = rooms.Sum(r => (r.PeopleAmount != null) ? r.PeopleAmount : 0);

            var project = context.Projects
                .Include(p => p.Rooms)
                .Where(p => p.Id == id)
                .FirstOrDefault();
            
            var airExchangeRooms = new List<AirExchangeRoomResource>();

            foreach (var room in rooms)
            {
                var roomTypeValues = context.RoomTypeValues.Where(rtv => rtv.RoomTypeId == room.RoomTypeId).ToList();
                int roomTypeValueId = 0;

                //Инициализация ИД показателей типа помещения
                if (roomTypeValues.Count == 1 ) 
                {
                    roomTypeValueId = roomTypeValues
                        .Where(rtv => rtv.RoomTypeId == room.RoomTypeId)
                        .SingleOrDefault().Id;
                }
                else 
                {
                    //TODO: Заменить логической обработкой
                    switch (room.RoomTypeId)
                    {
                        case 8:
                            roomTypeValueId = (peopleTotalAmount < 20) ? 5 : 6;
                            break;
                        case 9:
                            roomTypeValueId = (peopleTotalAmount < 20) ? 7 : 8;
                            break;
                        case 15:
                            roomTypeValueId = (peopleTotalAmount < 20) ? 14 : 15;
                            break;
                        case 20:
                            roomTypeValueId = (peopleTotalAmount < 20) ? 20 : 21;
                            break;
                        default:
                            break;
                    }
                }
                
                var roomTypeValue = roomTypeValues.Where(rtv => rtv.Id == roomTypeValueId).SingleOrDefault();
 
                //«Приток» по формуле: «Приток по жилой площади 1 м2, м3/ч» * «Общая площадь помещения»
                var inflowArea = roomTypeValue.InflowArea * areaTotalAmount;
                //«Вытяжка» по формуле: «Вытяжка по жилой площади 1 м2, м3/ч» * «Общая площадь помещения»
                var exhaustArea = roomTypeValue.ExhaustArea * areaTotalAmount;

                //«Приток» по формуле: «Приток по людям на 1 человека, м3/ч» * «Общее кол-во людей»
                var inflowPeople = roomTypeValue.InflowPeople * peopleTotalAmount;
                //«Вытяжка» по формуле: «Вытяжка по людям на 1 человека, м3/ч» * «Общее кол-во людей»
                var exhaustPeople = roomTypeValue.ExhaustPeople * peopleTotalAmount;

                //«Приток» по формуле: «Приток по кратности 1/ч, крат» * «Общий объем»
                var inflowMultiply = roomTypeValue.InflowMultiply * volumeTotalAmount;
                //«Вытяжка» по формуле: «Вытяжка по кратности 1/ч, крат» * «Общий объем»
                var exhaustMultiply = roomTypeValue.ExhaustMultiply * volumeTotalAmount;

                //«Приток» по константе
                var inflow = roomTypeValue.Inflow;
                //«Вытяжка» по константе
                var exhaust = roomTypeValue.Exhaust;

                //"Приток". Максимальное значение
                double?[] inflowArray = {inflowArea, inflowPeople, inflowMultiply, inflow};
                var inflowMaxValue = inflowArray.Max();

                //"Вытяжка". Максимальное значение
                double?[] exhaustArray = {exhaustArea, exhaustPeople, exhaustMultiply, exhaust};
                var exhaustMaxValue = exhaustArray.Max();

                var area = (room.Area != null) ? room.Area : room.Length * room.Width;
                var volume = area * room.Height;

                airExchangeRooms.Add(new AirExchangeRoomResource() {

                        Id = room.Id,
                        RoomNumber = room.RoomNumber,
                        RoomName = room.RoomName,
                        TempIn = roomTypeValue.TempIn,
                        Area = area,
                        Volume = volume,
                        PeopleAmount = room.PeopleAmount,
                        InflowMultiply = roomTypeValue.InflowMultiply,
                        ExhaustMultiply = roomTypeValue.ExhaustMultiply,
                        InflowCalc = inflowMaxValue,
                        ExhaustCalc = exhaustMaxValue
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