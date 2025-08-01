using App.API.Services;
using App.Application.Enums;
using App.Application.Interfaces;

namespace App.Application.Services;

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
            MessageType.Email => new EmailService(), //_serviceProvider.GetRequiredService<EmailService>(),
            MessageType.SMS => new SmsService(), //_serviceProvider.GetRequiredService<SmsService>(),
            _ => throw new NotSupportedException($"Message type {messageType} is not supported.")
        };
    }
}