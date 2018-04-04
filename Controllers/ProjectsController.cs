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
        public ProjectsController(IMapper mapper, IProjectRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpPost]
         public IActionResult GetAirExchangeReport([FromBody] ProjectResource projectResource) 
         {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var project =  mapper.Map<ProjectResource, Project>(projectResource);
            // var projectReport = GetAirExchangeReport(project);
            var result =  mapper.Map<Project, ProjectResource>(project);
            return Ok(result);
         }

    }
}