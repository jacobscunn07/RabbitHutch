using System;
using System.Collections.Generic;
using RabbitHutch.Domain;

namespace RabbitHutch.Application.Interfaces
{
    public interface IMessageId
    {
        IMessageHeaders WithMessageId(string id);
    }

    public interface IMessageHeaders
    {
        IMessageBody WithHeaders(IDictionary<string, string> headers);
    }

    public interface IMessageBody
    {
        IBusTechnology WithBody(string body);
    }

    public interface IBusTechnology
    {
        IApplicationId WithBusTechnology(string busTechnology);
    }

    public interface IApplicationId
    {
        IMessageTypes WithApplication(string applicationId);
    }

    public interface IMessageTypes
    {
        IMessageDocumentOptionalValues WithMessageTypes(string messageTypes);
    }

    public interface IMessageDocumentOptionalValues
    {
        IMessageDocumentOptionalValues IsError(bool error);

        MessageDocument Finish();
    }
}
