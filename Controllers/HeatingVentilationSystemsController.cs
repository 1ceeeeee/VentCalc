using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    [Route("api/[controller]")]
    public class HeatingVentilationSystemsController : BaseController {        
        public HeatingVentilationSystemsController(IMapper mapper, IUnitOfWork uow) : base(mapper, uow) {
        }

        [HttpGet]
        public async Task<IEnumerable<HeatingVentilationSystemResource>> ReadAll() {
            var heatingVentilationSystems = await UnitOfWork.Repository<HeatingVentilationSystem>().GetEnumerableAsync();
            return Mapper.Map<List<HeatingVentilationSystem>, List<HeatingVentilationSystemResource>>(heatingVentilationSystems.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadSingle(int id) {
            var heatingVentilationSystem = await UnitOfWork.Repository<HeatingVentilationSystem>().GetSingleIcludeMultipleAsync(x => x.Id == id);

            if (heatingVentilationSystem == null)
                return NotFound();

            var heatingVentilationSystemResource = Mapper.Map<HeatingVentilationSystem, HeatingVentilationSystemResource>(heatingVentilationSystem);

            return Ok(heatingVentilationSystemResource);
        }

//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] SaveProjectResource saveProjectResource) {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);
//
//            var userId = await GetCurrentUserIdAsync(saveProjectResource.CreateUserId);
//
//            var project = Mapper.Map<SaveProjectResource, Project>(saveProjectResource);
//            project.CreateDate = DateTime.Now;
//            project.CreateUserId = userId;
//
//            await UnitOfWork.Repository<Project>().AddAsync(project);
//            UnitOfWork.Commit();
//
//            var projectResource = Mapper.Map<Project, ProjectResource>(project);
//
//            return Ok(projectResource);
//        }
//
//        [HttpPut("UpdateProject")]
//        public async Task<IActionResult> Update([FromBody] SaveProjectResource saveProjectResource) {
//
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);
//
//            var project = await UnitOfWork.Repository<Project>().GetByIdAsync(saveProjectResource.Id);
//
//            if (project == null)
//                return NotFound();
//
//            Mapper.Map<SaveProjectResource, Project>(saveProjectResource, project);
//            project.UpdateDate = DateTime.Now;
//            project.UpdateUserId = await GetCurrentUserIdAsync(saveProjectResource.CreateUserId);
//
//            UnitOfWork.Commit();
//
//            var projectResource = Mapper.Map<Project, ProjectResource>(project);
//
//            return Ok(projectResource);
//        }
//
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> Delete(int id) {
//            
//            var project = await UnitOfWork.Repository<Project>().GetByIdAsync(id);
//
//            if (project == null)
//                return NotFound();
//            
//            project.Rooms = null;
//            UnitOfWork.Repository<Project>().Delete(project);
//
//            UnitOfWork.Commit();
//
//            return Ok(id);
//        }
//
//        [HttpGet]
//        [Route("~/api/Projects/{id:int}/AirExchange")]
//        public async Task<IActionResult> ReadAirExchange(int id) {
//            var project = await UnitOfWork.Repository<Project>().GetByIdAsync(id);
//
//            if (project == null)
//                return NotFound();
//
//            var airExchangeProject = CalculcateAirExchange(project.Id);
//
//            return Ok(airExchangeProject);
//        }
//
//        private AirExchangeProjectResource CalculcateAirExchange(int projectId) {            
//
//            var rooms = UnitOfWork.Repository<Room>().GetEnumerable(x => x.ProjectId == projectId);
//
//            var airExchangeRooms = new List<AirExchangeRoomResource>();
//
//            foreach (var room in rooms) {
//                var roomTypeValues = UnitOfWork.Repository<RoomTypeValue>().GetEnumerable(x => x.RoomTypeId == room.RoomTypeId).ToList();
//                int roomTypeValueId = 0;
//
//                //Площадь помещения
//                var roomArea = (room.Area != null) ? room.Area : room.Length * room.Width;
//                //Объем помещения
//                var roomVolume = (room.Area * room.Height != null) ? room.Area * room.Height : room.Length * room.Width * room.Height;
//                //Кол-во людей в помещении
//                var roomPeopleAmount = (room.PeopleAmount != null) ? room.PeopleAmount : 0;
//
//                //Инициализация ИД показателей типа помещения
//                if (roomTypeValues.Count == 1) {
//                    roomTypeValueId = roomTypeValues
//                        .Where(rtv => rtv.RoomTypeId == room.RoomTypeId)
//                        .SingleOrDefault().Id;
//                } else {
//                    //TODO: Заменить логической обработкой
//                    //TODO: Добавить "валидацию" по обязательному указанию площади и кол-ву людей для тех типов помещений,
//                    //которые их используют по условию, например "при общей площади квартиры на одного человека менее 20 м²"
//                    //Площадь на одного человека
//                    var roomPerPeopleArea = (roomArea != 0 && roomPeopleAmount != 0) ? roomArea / roomPeopleAmount : 0;
//                    switch (room.RoomTypeId) {
//                        case 8:
//                            roomTypeValueId = (roomPerPeopleArea < 20) ? 5 : 6;
//                            break;
//                        case 9:
//                            roomTypeValueId = (roomPerPeopleArea < 20) ? 7 : 8;
//                            break;
//                        case 15:
//                            roomTypeValueId = (roomPerPeopleArea < 20) ? 14 : 15;
//                            break;
//                        case 20:
//                            roomTypeValueId = (roomPerPeopleArea < 20) ? 20 : 21;
//                            break;
//                        default:
//                            break;
//                    }
//                }
//
//                var roomTypeValue = roomTypeValues.Where(rtv => rtv.Id == roomTypeValueId).SingleOrDefault();
//
//                //«Приток» по формуле: «Приток по жилой площади 1 м2, м3/ч» * «Площадь помещения»
//                var inflowArea = roomTypeValue.InflowArea * roomArea;
//                //«Вытяжка» по формуле: «Вытяжка по жилой площади 1 м2, м3/ч» * «Площадь помещения»
//                var exhaustArea = roomTypeValue.ExhaustArea * roomArea;
//
//                //«Приток» по формуле: «Приток по кратности 1/ч, крат» * «Объем помещения»
//                var inflowMultiply = roomTypeValue.InflowMultiply * roomVolume;
//                //«Вытяжка» по формуле: «Вытяжка по кратности 1/ч, крат» * «Объем помещения»
//                var exhaustMultiply = roomTypeValue.ExhaustMultiply * roomVolume;
//
//                //«Приток» по формуле: «Приток по людям на 1 человека, м3/ч» * «Кол-во людей в помещении»
//                var inflowPeople = roomTypeValue.InflowPeople * roomPeopleAmount;
//                //«Вытяжка» по формуле: «Вытяжка по людям на 1 человека, м3/ч» * «Кол-во людей в помещении»
//                var exhaustPeople = roomTypeValue.ExhaustPeople * roomPeopleAmount;
//
//                //«Приток» по константе
//                var inflow = roomTypeValue.Inflow;
//                //«Вытяжка» по константе
//                var exhaust = roomTypeValue.Exhaust;
//
//                //"Приток". Максимальное значение
//                double?[] inflowArray = {
//                    inflowArea,
//                    inflowPeople,
//                    inflowMultiply,
//                    inflow
//                };
//                var inflowMaxValue = inflowArray.Max();
//
//                //"Вытяжка". Максимальное значение
//                double?[] exhaustArray = {
//                    exhaustArea,
//                    exhaustPeople,
//                    exhaustMultiply,
//                    exhaust
//                };
//                var exhaustMaxValue = exhaustArray.Max();
//
//                airExchangeRooms.Add(new AirExchangeRoomResource() {
//
//                    Id = room.Id,
//                        RoomNumber = room.RoomNumber,
//                        RoomName = room.RoomName,
//                        TempIn = roomTypeValue.TempIn,
//                        Area = roomArea,
//                        Volume = roomVolume,
//                        PeopleAmount = room.PeopleAmount,
//                        InflowMultiply = roomTypeValue.InflowMultiply,
//                        ExhaustMultiply = roomTypeValue.ExhaustMultiply,
//                        InflowCalc = inflowMaxValue,
//                        ExhaustCalc = exhaustMaxValue,
//                        ExhaustSystem = room.ExhaustSystem,
//                        InflowSystem = room.InflowSystem
//                });
//            }
//
//            var airExchangeProject = new AirExchangeProjectResource() {
//                Id = projectId,
//                InflowTotal = airExchangeRooms.Sum(x => x.InflowCalc),
//                ExhaustTotal = airExchangeRooms.Sum(x => x.ExhaustCalc),
//                AirExchangeRooms = airExchangeRooms
//            };
//
//            return airExchangeProject;
//        }

    }
}