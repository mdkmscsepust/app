using app.Services;
using Microsoft.AspNetCore.Mvc;
using app.Helpers;
namespace app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    // private readonly IMessageServiceFactory _messageServiceFactory;
    // public NotificationController(IMessageServiceFactory messageServiceFactory)
    // {
    //     _messageServiceFactory = messageServiceFactory;
    // }
    private readonly Func<MessageType, IMessageService>  _messageFactory;
    public NotificationController(Func<MessageType, IMessageService> messageFactory)
    {
        _messageFactory = messageFactory;
    }

    [HttpGet("SendMessage")]
    public ActionResult SendMessage(string message)
    {
        MessageType type;

        if (!Enum.TryParse<MessageType>(message, true, out type))
        {
            return BadRequest("Invalid message type");
        }

        //var service = _messageServiceFactory.Create(type);
        var service = _messageFactory(type);
        Console.WriteLine($"Message type: {service}");
        service.SendMessage($"Message: {message} of type {type}");
        //_messageService.SendMessage(message);
        return Ok("Message sent successfully");
    }
}