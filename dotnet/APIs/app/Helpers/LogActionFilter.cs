using Microsoft.AspNetCore.Mvc.Filters;

namespace app.Helpers;

public class LogActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var actionName = context.ActionDescriptor.DisplayName;
        Console.WriteLine($"Action Starting: {actionName}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Console.WriteLine("Action Finished");
    }
}