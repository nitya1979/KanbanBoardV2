using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;
using System.Linq;
using System.Text;

namespace KanbanAPI.Filters
{
    public class ApiValidationFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Log.Information(Newtonsoft.Json.JsonConvert.SerializeObject(context.Result));
            base.OnActionExecuted(context);
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                
                var Errors = context.ModelState.SelectMany(x => x.Value.Errors)
                                    .Select(x => x.ErrorMessage).ToArray();

                foreach( var err in Errors)
                {
                    Log.Error(err);
                }

                context.Result = new BadRequestObjectResult(Errors);
            }

            base.OnActionExecuting(context);
        }
    }
}
