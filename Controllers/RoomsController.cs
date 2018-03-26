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
        private readonly VentCalcDbContext context;
        public RoomsController(IMapper mapper, VentCalcDbContext context, IRoomRepository repository)
        {
            this.mapper = mapper;
            this.context = context;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomResource>> GetAll()
        {
            var rooms = await repository.GetAll();

            return mapper.Map<List<Room>, List<RoomResource>>(rooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var room = await repository.GetSingle(id);

            if (room == null)
                return NotFound();

            var SaveRoomResource = mapper.Map<Room, RoomResource>(room);

            return Ok(SaveRoomResource);

        }

    }
}