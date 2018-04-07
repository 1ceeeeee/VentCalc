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
         public IActionResult CreateProject ([FromBody] ProjectResource projectResource) 
         {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var project =  mapper.Map<ProjectResource, Project>(projectResource);
            repository.CreateProject(project);
            return Ok(project);
         }
        
        [HttpPost("{id}")]
         public IActionResult CalculateProject (int id) 
         {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            repository.CalculateProject(id);
            return Ok();
         }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            var project = await repository.GetSingle(id);

            if (project == null)
                return NotFound();

            var projectResource = mapper.Map<Project, ProjectResource>(project);

            return Ok(projectResource);
        }


    }
}