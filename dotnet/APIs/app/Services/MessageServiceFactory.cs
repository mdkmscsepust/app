using app.Helpers;

namespace app.Services;

public class MessageServiceFactory : IMessageServiceFactory
{
    private readonly IServiceProvider _serviceProvider;
    public MessageServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public IMessageService Create(MessageType messageType)
    {
        return messageType switch
        {
            MessageType.Email => _serviceProvider.GetRequiredService<EmailService>(),
            MessageType.SMS => _serviceProvider.GetRequiredService<SmsService>(),
            _ => throw new NotSupportedException($"Message type {messageType} is not supported.")
        };
    }
}