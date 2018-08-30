using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KanbanBoardCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KanbanAPI.Controllers
{
    public class KanbanController : Controller
    {
        protected IActionResult GetResult( KanbanResult result)
        {
            if (result.Success)
                return Ok(result.Result);
            else
                return BadRequest(result.Errors.ToArray());
        }
    }
}
