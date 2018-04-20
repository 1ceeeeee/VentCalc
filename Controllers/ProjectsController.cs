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

        [HttpGet]
        public async Task<IEnumerable<ProjectResource>> ReadAll()
        {
            var projects = await repository.ReadAll();

            return mapper.Map<List<Project>, List<ProjectResource>>(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadSingle(int id)
        {
            var project = await repository.ReadSingle(id);

            if (project == null)
                return NotFound();

            var projectResource = mapper.Map<Project, ProjectResource>(project);

            return Ok(projectResource);
        }

        [HttpPost]
         public async Task<IActionResult> Create ([FromBody] SaveProjectResource saveProjectResource) 
         {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var project = mapper.Map<SaveProjectResource, Project>(saveProjectResource);
            project = await repository.Create(project);
            var projectResource = mapper.Map<Project, ProjectResource>(project);

            return Ok(projectResource);
         }

         [HttpPut("{id}")]
         public async Task<IActionResult> Update (int id, [FromBody] SaveProjectResource saveProjectResource) 
         {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var project = await repository.ReadSingle(id);

            if (project == null)
                return NotFound();

            mapper.Map<SaveProjectResource, Project>(saveProjectResource, project);
            project = await repository.Update(project);
            var projectResource = mapper.Map<Project, ProjectResource>(project);

            return Ok(projectResource);
         }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var project = await repository.ReadSingle(id);

            if (project == null)
                return NotFound();

            repository.Delete(id);

            return Ok(id);
        }

        [HttpGet]
        [Route("~/api/Projects/{id:int}/AirExchange")]
        public async Task<IActionResult> ReadAirExchange(int id)
        {
            var project = await repository.ReadSingle(id);

            if (project == null)
                return NotFound();

            var airExchangeProject = repository.ReadAirExchange(id);

            return Ok(airExchangeProject);
        }
    }
}