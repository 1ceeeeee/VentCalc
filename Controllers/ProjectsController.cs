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
    public class ProjectsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IProjectRepository repository;
        private readonly VentCalcDbContext context;
        public ProjectsController(IMapper mapper, IProjectRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
    }
}