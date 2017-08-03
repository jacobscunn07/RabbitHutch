using System.Collections.Generic;
using RabbitHutch.Domain;
using RabbitHutch.Domain.Interfaces;
using RabbitHutch.Host.Application.ServiceBusTechnologies.NServiceBus;

namespace RabbitHutch.Host.Application
{
    public class MessageDocumentBuilder :
        IMessageHeaders,
        IMessageBody,
        IBusTechnology,
        IApplicationId,
        IMessageTypes,
        IMessageDocumentOptionalValues
    {
        private IDictionary<string, string> _headers;
        private string _body;
        private string _busTechnology;
        private string _applicationId;
        private string _messageTypes;

        private MessageDocumentBuilder()
        {
        }

        public static IMessageHeaders BuildDocument()
        {
            return new MessageDocumentBuilder();
        }

        public IMessageBody WithHeaders(IDictionary<string, string> headers)
        {
            _headers = headers;
            return this;
        }

        public IBusTechnology WithBody(string body)
        {
            _body = body;
            return this;
        }

        public IApplicationId WithBusTechnology(string busTechnology)
        {
            _busTechnology = busTechnology;
            return this;
        }

        public IMessageTypes WithApplication(string applicationId)
        {
            _applicationId = applicationId;
            return this;
        }

        public IMessageDocumentOptionalValues WithMessageTypes(string messageTypes)
        {
            _messageTypes = messageTypes;
            return this;
        }

        public MessageDocument Finish()
        {
            return new MessageDocument
            {
                Headers = _headers,
                Body = _body,
                ServiceBusTechnology = _busTechnology,
                ApplicationId = _applicationId,
                MessageTypes = _messageTypes,
                IsError = _headers.ContainsKey(Headers.ExceptionType)
            };
        }
    }
}
