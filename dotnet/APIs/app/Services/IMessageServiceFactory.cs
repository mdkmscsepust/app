using app.Helpers;

namespace app.Services;

public interface IMessageServiceFactory
{
    IMessageService Create(MessageType messageType);
}