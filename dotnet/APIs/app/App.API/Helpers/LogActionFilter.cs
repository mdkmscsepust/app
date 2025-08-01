using Microsoft.AspNetCore.Mvc.Filters;

namespace App.API.Helpers;

public class LogActionFilter : IActionFilter
{
    DateTime time = DateTime.Now;
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var actionName = context.ActionDescriptor.DisplayName;
        Console.WriteLine($"Action Starting: {actionName} at {time}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Action Finished at " + (time -DateTime.Now).Milliseconds + " ms");
    }
}