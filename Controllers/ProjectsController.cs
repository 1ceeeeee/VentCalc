using System;
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
    public class ProjectsController : BaseController {
        private readonly IProjectRepository repository;
        public ProjectsController(IMapper mapper, IUnitOfWork uow, IProjectRepository repository) : base(mapper, uow) {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectResource>> ReadAll() {
            var projects = await repository.ReadAll();

            return Mapper.Map<List<Project>, List<ProjectResource>>(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadSingle(int id) {
            var project = await UnitOfWork.Repository<Project>().GetByIdAsync(id);

            if (project == null)
                return NotFound();

            var projectResource = Mapper.Map<Project, ProjectResource>(project);

            return Ok(projectResource);
        }

        [HttpGet]
        [Route("~/api/Projects/GetAllByUserId/{createUserId}")]
        public async Task<IEnumerable<ProjectResource>> GetAllByUserId(string createUserId){
            var userId = await GetCurrentUserIdAsync(createUserId);
            if(userId == 0)
                return null;

            var projects = await UnitOfWork.Repository<Project>().GetEnumerableAsync(x => x.CreateUserId == userId);

            return Mapper.Map<List<Project>, List<ProjectResource>>(projects.ToList());

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveProjectResource saveProjectResource) {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = await GetCurrentUserIdAsync(saveProjectResource.CreateUserId);

            var project = Mapper.Map<SaveProjectResource, Project>(saveProjectResource);
            project.CreateDate = DateTime.Now;
            project.CreateUserId = userId;

            await UnitOfWork.Repository<Project>().AddAsync(project);
            UnitOfWork.Commit();

            var projectResource = Mapper.Map<Project, ProjectResource>(project);

            return Ok(projectResource);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SaveProjectResource saveProjectResource) {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var project = await repository.ReadSingle(saveProjectResource.Id);

            if (project == null)
                return NotFound();

            Mapper.Map<SaveProjectResource, Project>(saveProjectResource, project);
            project = await repository.Update(project);

            UnitOfWork.Commit();

            var projectResource = Mapper.Map<Project, ProjectResource>(project);

            return Ok(projectResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            
            var project = await UnitOfWork.Repository<Project>().GetByIdAsync(id);

            if (project == null)
                return NotFound();

            UnitOfWork.Repository<Project>().Delete(project);

            UnitOfWork.Commit();

            return Ok(id);
        }

        [HttpGet]
        [Route("~/api/Projects/{id:int}/AirExchange")]
        public async Task<IActionResult> ReadAirExchange(int id) {
            var project = await repository.ReadSingle(id);

            if (project == null)
                return NotFound();

            var airExchangeProject = repository.ReadAirExchange(id);

            return Ok(airExchangeProject);
        }

    }
}