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

            var airExchangeRooms = new List<AirExchangeRoomResource>();

            foreach (var room in rooms)
            {
                var roomTypeValues = context.RoomTypeValues.Where(rtv => rtv.RoomTypeId == room.RoomTypeId).ToList();
                int roomTypeValueId = 0;

                //Площадь помещения
                var roomArea =  (room.Area != null) ? room.Area : room.Length * room.Width;
                //Объем помещения
                var roomVolume = (room.Area * room.Height != null) ? room.Area * room.Height : room.Length * room.Width * room.Height;
                //Кол-во людей в помещении
                var roomPeopleAmount = (room.PeopleAmount != null) ? room.PeopleAmount : 0;

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
                    //TODO: Добавить "валидацию" по обязательному указанию площади и кол-ву людей для тех типов помещений,
                    //которые их используют по условию, например "при общей площади квартиры на одного человека менее 20 м²"
                    //Площадь на одного человека
                    var roomPerPeopleArea = (roomArea != 0 && roomPeopleAmount != 0 ) ? roomArea/roomPeopleAmount : 0;
                    switch (room.RoomTypeId)
                    {
                        case 8:
                            roomTypeValueId = (roomPerPeopleArea < 20) ? 5 : 6;
                            break;
                        case 9:
                            roomTypeValueId = (roomPerPeopleArea < 20) ? 7 : 8;
                            break;
                        case 15:
                            roomTypeValueId = (roomPerPeopleArea < 20) ? 14 : 15;
                            break;
                        case 20:
                            roomTypeValueId = (roomPerPeopleArea < 20) ? 20 : 21;
                            break;
                        default:
                            break;
                    }
                }
                
                var roomTypeValue = roomTypeValues.Where(rtv => rtv.Id == roomTypeValueId).SingleOrDefault();
 
                //«Приток» по формуле: «Приток по жилой площади 1 м2, м3/ч» * «Площадь помещения»
                var inflowArea = roomTypeValue.InflowArea * roomArea;
                //«Вытяжка» по формуле: «Вытяжка по жилой площади 1 м2, м3/ч» * «Площадь помещения»
                var exhaustArea = roomTypeValue.ExhaustArea * roomArea;

                //«Приток» по формуле: «Приток по кратности 1/ч, крат» * «Объем помещения»
                var inflowMultiply = roomTypeValue.InflowMultiply * roomVolume;
                //«Вытяжка» по формуле: «Вытяжка по кратности 1/ч, крат» * «Объем помещения»
                var exhaustMultiply = roomTypeValue.ExhaustMultiply * roomVolume;

                //«Приток» по формуле: «Приток по людям на 1 человека, м3/ч» * «Кол-во людей в помещении»
                var inflowPeople = roomTypeValue.InflowPeople * roomPeopleAmount;
                //«Вытяжка» по формуле: «Вытяжка по людям на 1 человека, м3/ч» * «Кол-во людей в помещении»
                var exhaustPeople = roomTypeValue.ExhaustPeople * roomPeopleAmount;

                //«Приток» по константе
                var inflow = roomTypeValue.Inflow;
                //«Вытяжка» по константе
                var exhaust = roomTypeValue.Exhaust;

                //"Приток". Максимальное значение
                double?[] inflowArray = 
                {
                    inflowArea, 
                    inflowPeople, 
                    inflowMultiply, 
                    inflow
                };
                var inflowMaxValue = inflowArray.Max();

                //"Вытяжка". Максимальное значение
                double?[] exhaustArray = 
                {
                    exhaustArea, 
                    exhaustPeople, 
                    exhaustMultiply, 
                    exhaust
                };
                var exhaustMaxValue = exhaustArray.Max();

                airExchangeRooms.Add(new AirExchangeRoomResource() {

                        Id = room.Id,
                        RoomNumber = room.RoomNumber,
                        RoomName = room.RoomName,
                        TempIn = roomTypeValue.TempIn,
                        Area = roomArea,
                        Volume = roomVolume,
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
                Id = id,
                InflowTotal = airExchangeRooms.Sum(x => x.InflowCalc),
                ExhaustTotal = airExchangeRooms.Sum(x => x.ExhaustCalc),
                AirExchangeRooms = airExchangeRooms
            };

            return airExchangeProject;
        }


    }
}