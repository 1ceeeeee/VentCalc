using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Persistence;
using VentCalc.Repositories;

namespace VentCalc.Controllers {
    [Route("api/[controller]")]
    public class RoomTypesController : BaseController {
        public RoomTypesController(IMapper mapper, IUnitOfWork uow) : base(mapper, uow) { }

        [HttpGet]
        public async Task<IEnumerable<RoomTypeResource>> GetAll() {
            var roomTypes =
                await UnitOfWork.Repository<RoomType>().GetEnumerableIcludeMultipleAsync(x => x.DeleteUsertId == null, x => x.BuildingType);

            var roomTypeResources = new List<RoomTypeResource>();
            foreach (var roomType in roomTypes) {
                roomTypeResources.Add(new RoomTypeResource() {
                    Id = roomType.Id,
                        RoomTypeName = roomType.RoomTypeName,
                        BuildingTypeId = roomType.BuildingTypeId,
                        RoomTypeBuildingTypeName = $"{roomType.RoomTypeName} ({roomType.BuildingType.BuildingTypeName})"
                });
            }
            return roomTypeResources;
        }

    }
}