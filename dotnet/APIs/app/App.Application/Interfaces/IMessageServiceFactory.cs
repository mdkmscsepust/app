using App.Application.Enums;
using App.Application.Interfaces;

namespace App.API.Services;

public interface IMessageServiceFactory
{
    IMessageService Create(MessageType messageType);
}