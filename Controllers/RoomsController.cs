using System.Collections.Generic;
using System.Linq;
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
    public class RoomsController : BaseController {
        // private readonly IMapper mapper;
        // private IUnitOfWork UnitOfWork;
        public RoomsController(IMapper mapper, IUnitOfWork uow) : base(mapper, uow) {
            // this.mapper = mapper;
            // this.UnitOfWork = uow;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomResource>> ReadAll() {
            var rooms = await UnitOfWork.Repository<Room>().GetEnumerableAsync();

            return Mapper.Map<List<Room>, List<RoomResource>>(rooms.ToList());
        }

        [HttpGet]
        [Route("~/api/Projects/{projectId:int}/Rooms")]
        public async Task<IEnumerable<RoomResource>> ReadAll(int projectId) {
            var rooms = await UnitOfWork.Repository<Room>().GetEnumerableAsync(x => x.ProjectId == projectId);

            return Mapper.Map<List<Room>, List<RoomResource>>(rooms.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadSingle(int id) {
            var room = await UnitOfWork.Repository<Room>().GetByIdAsync(id);

            if (room == null)
                return NotFound();

            var roomResource = Mapper.Map<Room, RoomResource>(room);

            return Ok(roomResource);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveRoomResource saveRoomResource) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = Mapper.Map<SaveRoomResource, Room>(saveRoomResource);
            await UnitOfWork.Repository<Room>().AddAsync(room);
            UnitOfWork.Commit();

            var roomResource = Mapper.Map<Room, RoomResource>(room);

            return Ok(roomResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaveRoomResource saveRoomResource) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = await UnitOfWork.Repository<Room>().GetByIdAsync(id);

            if (room == null)
                return NotFound();

            Mapper.Map<SaveRoomResource, Room>(saveRoomResource, room);
            UnitOfWork.Repository<Room>().MarkUpdated(room);
            var roomResource = Mapper.Map<Room, RoomResource>(room);

            UnitOfWork.Commit();

            return Ok(roomResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {

            var room = await UnitOfWork.Repository<Room>().GetByIdAsync(id);

            if (room == null)
                return NotFound();

            UnitOfWork.Repository<Room>().Delete(room);
            UnitOfWork.Commit();

            return Ok(id);
        }

    }
}