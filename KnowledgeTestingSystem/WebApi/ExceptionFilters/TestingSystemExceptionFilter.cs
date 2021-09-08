using BLL.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.ExceptionFilters
{
    public class TestingSystemExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is TestingSystemException exception)
            {
                context.Result = new BadRequestObjectResult(exception.Message);

                context.ExceptionHandled = true;
            }
        }
    }
}
