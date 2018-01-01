using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KanbanBoardCore;
using KanbanAPI.Helper;

namespace KanbanAPI.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ProjectController : Controller
    {
        // GET: api/Project
        [HttpGet]
        [Route("Projects")]
        [Route("Users/{userName}/Projects")]
        public async Task<IActionResult> Get(string userName, DateTime? fromDate, DateTime? toDate)
        {
            return await Task.Factory.StartNew(() =>
            {
                Console.WriteLine(this.Request.Path);
                Console.WriteLine(this.Request.QueryString);
                Console.WriteLine("userName :{0}", userName);
                Console.WriteLine("From Date : {0}", fromDate);
                Console.WriteLine("To Date : {0}", toDate);
                List<Project> p = new List<Project>();
                p.Add(new Project { ProjectName = "Test1", DueDate = DateTime.Now.Date });
                p.Add(new Project { ProjectName = "Test2", DueDate = DateTime.Now.Date });
                p.Add(new Project { ProjectName = "Test3", DueDate = DateTime.Now.Date });
                p.Add(new Project { ProjectName = "Test4", DueDate = DateTime.Now.Date });
                KanbanCollection<Project> values = new KanbanCollection<Project>(p, 5);
                
                return Ok(new ApiOkResponse(values));
            });

        }

        // GET: api/Project/5
        [HttpGet]
        [Route("Project/{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Project
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Project/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
