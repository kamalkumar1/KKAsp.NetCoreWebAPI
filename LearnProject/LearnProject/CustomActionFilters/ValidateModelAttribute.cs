using LearnProject.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LearnProject.CustomActionFilters
{
    public class ValidateModelAttribute:ActionFilterAttribute
    {
        
        /// <summary>
        /// This called on after action get's completed while sending response to client
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
        /// <summary>
        /// This called before method get executed  while incoming request from client
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            if (!context.ModelState.IsValid)
            {
                context.Result = new OkObjectResult(new BaseModel { Statuscode=400,Message="Validation Failed"});
            }
        }
        
    }
}
