using System.Collections.Generic;

namespace RabbitHutch.Host.Domain
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
                IsError = _headers.ContainsKey(ServiceBusTechnologies.NServiceBus.Headers.ExceptionType)
            };
        }
    }
}
