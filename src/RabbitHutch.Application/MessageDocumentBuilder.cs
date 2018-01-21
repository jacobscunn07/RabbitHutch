using System;
using System.Collections.Generic;
using RabbitHutch.Application.Interfaces;
using RabbitHutch.Domain;

namespace RabbitHutch.Application
{
    public class MessageDocumentBuilder :
        IMessageId,
        IMessageHeaders,
        IMessageBody,
        IBusTechnology,
        IApplicationId,
        IMessageTypes,
        IProcessedDateTime,
        IMessageDocumentOptionalValues
    {
        private string _messageId;
        private IDictionary<string, string> _headers;
        private string _body;
        private string _busTechnology;
        private string _applicationId;
        private string _messageTypes;
        private bool _isError;
        private DateTime _processedDateTime;

        private MessageDocumentBuilder()
        {
            _isError = false;
        }

        public static IMessageId BuildDocument()
        {
            return new MessageDocumentBuilder();
        }

        public IMessageHeaders WithMessageId(string id)
        {
            _messageId = id;
            return this;
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

        public IProcessedDateTime WithMessageTypes(string messageTypes)
        {
            _messageTypes = messageTypes;
            return this;
        }

        public IMessageDocumentOptionalValues WithProcessedDateTime(DateTime processedDateTime)
        {
            _processedDateTime = processedDateTime;
            return this;
        }

        public IMessageDocumentOptionalValues IsError(bool error)
        {
            _isError = error;
            return this; 
        }

        public MessageDocument Finish()
        {
            return new MessageDocument
            {
                MessageId = _messageId,
                Headers = _headers,
                Body = _body,
                ServiceBusTechnology = _busTechnology,
                ApplicationId = _applicationId,
                MessageTypes = _messageTypes,
                IsError = _isError,
                ProcessedDateTime = _processedDateTime
            };
        }
    }
}
