using KanbanBoardCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanAPI.Filters
{
    public class KanbanExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private bool _handledError = false;

        public override void OnException(ExceptionContext context)
        {
            FormatMessage(context);

            base.OnException(context);
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            FormatMessage(context);

            return base.OnExceptionAsync(context);
        }

        private void FormatMessage(ExceptionContext context)
        {
            if (!_handledError)
            {
                _handledError = true;
                Log.Error(context.Exception, $"(OnExceptionAsync) Error in {context.HttpContext.Request.Path}");
            }

            context.Result = new BadRequestObjectResult(
                new List<string>() { "Something bad happened, please try again later" });

            context.HttpContext.Response.StatusCode = 500;
        }
    }
}
