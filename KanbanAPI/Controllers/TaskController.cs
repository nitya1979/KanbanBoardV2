using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KanbanAPI.ViewModels;
using KanbanBoardCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KanbanAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/task")]
    public class TaskController : Controller
    {
        TaskService _taskService = null;

        public TaskController(TaskService taskService)
        {
            this._taskService = taskService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("priorities")]
        public async Task<IActionResult> Priorities()
        {
            var taskPriorities = await _taskService.GetPriorities();

            return Ok(taskPriorities);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProjectTaskViewModel task)
        {
            
            if(ModelState.IsValid)
            {

                ProjectTask projectTask = Mapper.Map<ProjectTask>(task);

                if( task.TaskID == 0)
                {
                    
                    projectTask.CreatedBy = User.Identity.Name;
                    projectTask.CreateDate = DateTime.Now;
                }
                else
                {
                    
                    projectTask = await _taskService.GetTask(task.TaskID);

                    projectTask.ModifiedBy = User.Identity.Name;
                    projectTask.ModifyDate = DateTime.Now;
                }

                await _taskService.SaveTask(projectTask);
            }

            return Ok();
        }

        [HttpGet]
        [Route("duetasks")]
        public async Task<IActionResult> DueByDays()
        {
            var tasks = await _taskService.GetTasks(User.Identity.Name, 7);

            return Ok(tasks);
        }

    }
}
