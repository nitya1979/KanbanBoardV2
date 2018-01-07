using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanAPI.Filters
{
    public class ApiValidationFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
            {
                var Errors = context.ModelState.SelectMany(x => x.Value.Errors)
                                    .Select(x => x.ErrorMessage).ToArray();

                context.Result = new BadRequestObjectResult(Errors);
            }

            base.OnActionExecuting(context);
        }
    }
}
