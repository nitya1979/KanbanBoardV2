using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KanbanBoardCore;
using KanbanAPI.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net.Http;

namespace KanbanAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectController : Controller
    {

        ProjectService _projectService = null;
        public ProjectController(ProjectService projectService)
        {
            this._projectService = projectService;
        }

        // GET: api/Project
        [HttpGet]
        //[Route("Projects")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int pageNo = 0, int count=0)
        {
            var userName = Request.HttpContext.User.Identity.Name;

            KanbanCollection<Project> projects = null;

            if (pageNo == 0 || count == 0)
                projects = await _projectService.GetAllProjects(userName);
            else
                projects = await _projectService.GetAllProjects(userName, pageNo, count);

            return Ok(projects);

        }


        // GET: api/Project/5
        [HttpGet]
        [Route("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0)
                return NotFound(new string[] { "Invalid Project ID" });

            var project = await _projectService.GetProject(id);

            if (project == null)
                return NotFound(new string[] { "Project Not Found" });

            return Ok(project);
        }
        
        // POST: api/Project
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProjectViewModel model)
        {
            
            Project proj = Mapper.Map<Project>(model);
            proj.QuadrantID = model.Quadrant;
            if (proj.ProjectID == 0)
            {
                proj.CreatedBy = User.Identity.Name;
                proj.CreateDate = DateTime.Now;
            }
            else
            {
                proj.ModifiedBy = User.Identity.Name;
                proj.ModifyDate = DateTime.Now;
            }

            await _projectService.SaveProject(proj);

            return Ok();
        }
        
        // PUT: api/Project/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ProjectViewModel model)
        {
            if (id != model.ProjectID)
                throw new ArgumentException("Incorrect project detail.");

            Project proj = Mapper.Map<Project>(model);
            proj.QuadrantID = model.Quadrant;
            await _projectService.SaveProject(proj);

            return Ok();
        }
        
        [HttpGet("{id}/stages")]
        [AllowAnonymous]
        public async Task<IActionResult> Stages(int id)
        {
            if (id == 0)
                return BadRequest(new string[] { "Invalid project" });

            List<ProjectStage> stages = await _projectService.GetStages(id);

            return Ok(stages.ToArray());

        }

        [HttpPost("{id}/stages")]
        public async Task<IActionResult> Stages([FromBody]StageViewModel model)
        {
            ProjectStage stage = Mapper.Map<ProjectStage>(model);

            await _projectService.SaveStage(stage);

            return Ok();
        }

        //[HttpPut("Projects/{id}/Complete")]
        //public async Task<IActionResult> Complete(int id)
        //{
            
        //}
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }

        [HttpGet("quadrants")]
        public async Task<IActionResult> Quadrants()
        {
            var quadrants = await _projectService.GetQuadrants();

            return Ok(quadrants);
        }

        [HttpGet("important/{count}")]
        public async Task<IActionResult> Important(int count = 4)
        {
            var userName = User.Identity.Name;

            var projects = await _projectService.GetImportant(userName, count);

            return Ok(projects);

        }

        [HttpGet]
        [Route("search/{name?}")]
        public async Task<IActionResult> Search(string name = "")
        {
            Console.WriteLine("name :" + name);
            var projects = await _projectService.GetAllProjects(Request.HttpContext.User.Identity.Name);

            if (!string.IsNullOrEmpty(name))
                return Ok(projects.Items.Where(p => p.ProjectName.Contains(name, StringComparison.CurrentCultureIgnoreCase)));
            else
                return Ok(projects.Items);

        }

    }
}
