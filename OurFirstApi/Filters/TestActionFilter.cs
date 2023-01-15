using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace OurFirstApi.Filters;

public class TestActionFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        
        string varIpAddress = string.Empty;
        var testValue = context.HttpContext.Request.Headers["Test"];
        
        Console.WriteLine(testValue);
        
        if (testValue != "123456")
        {
            context.Result = new UnauthorizedResult();
            base.OnActionExecuting(context);
        }
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {

        
    }
    public override void OnResultExecuted(ResultExecutedContext filterContext)
    {
    }
    public override void OnResultExecuting(ResultExecutingContext filterContext)
    {
        filterContext.Result = new ContentResult
        {
            Content = "test"
        };
    }
}

public class Response
{
    public string Message { get; set; }
}