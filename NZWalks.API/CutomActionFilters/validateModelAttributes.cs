using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NZWalks.API.CutomActionFilters
{
	public class validateModelAttributes : ActionFilterAttribute
	{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //having this method is better practice than writting if else statement in each method that has requirements
            if(context.ModelState.IsValid == false)
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}

