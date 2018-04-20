using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VentCalc.Controllers.Resources;
using VentCalc.Models;
using VentCalc.Persistence;

namespace VentCalc.Controllers
{
    [Route("api/[controller]")]
    public class RoomsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IRoomRepository repository;
        public RoomsController(IMapper mapper, IRoomRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomResource>> ReadAll()
        {
            var rooms = await repository.ReadAll();

            return mapper.Map<List<Room>, List<RoomResource>>(rooms);
        }

        [HttpGet]
        [Route("~/api/Projects/{projectId:int}/Rooms")]
        public async Task<IEnumerable<RoomResource>> ReadAll(int projectId)
        {
            var rooms = await repository.ReadAll(projectId);

            return mapper.Map<List<Room>, List<RoomResource>>(rooms);
        }        

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadSingle(int id)
        {
            var room = await repository.ReadSingle(id);

            if (room == null)
                return NotFound();

            var roomResource = mapper.Map<Room, RoomResource>(room);

            return Ok(roomResource);
        }

        [HttpPost]
         public async Task<IActionResult> Create ([FromBody] SaveRoomResource saveRoomResource) 
         {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = mapper.Map<SaveRoomResource, Room>(saveRoomResource);
            room = await repository.Create(room);
            var roomResource = mapper.Map<Room, RoomResource>(room);

            return Ok(roomResource);
         }

         [HttpPut("{id}")]
         public async Task<IActionResult> Update (int id, [FromBody] SaveRoomResource saveRoomResource) 
         {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = await repository.ReadSingle(id);

            if (room == null)
                return NotFound();

            mapper.Map<SaveRoomResource, Room>(saveRoomResource, room);
            room = await repository.Update(room);
            var roomResource = mapper.Map<Room, RoomResource>(room);

            return Ok(roomResource);
         }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var room =  await repository.ReadSingle(id);

            if (room == null)
                return NotFound();

            repository.Delete(id);

            return Ok(id);
        }

    }
}