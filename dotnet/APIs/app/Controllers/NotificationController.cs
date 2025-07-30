using app.Services;
using Microsoft.AspNetCore.Mvc;
using app.Helpers;
namespace app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly Func<MessageType, IMessageService>  _messageFactory;
    public NotificationController(Func<MessageType, IMessageService> messageFactory)
    {
        _messageFactory = messageFactory;
    }

    [HttpGet("SendMessage")]
    public ActionResult SendMessage(string message)
    {
        MessageType type;

        if (!Enum.TryParse(message, true, out type))
        {
            return BadRequest("Invalid message type");
        }
        
        var service = _messageFactory(type);
        service.SendMessage(type);
        //_messageService.SendMessage(message);
        return Ok("Message sent successfully");
    }
}