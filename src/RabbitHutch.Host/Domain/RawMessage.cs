using RabbitMQ.Client.Events;
using System.Collections.Generic;
using System.Text;

namespace RabbitHutch.Host.Domain
{
    public class RawMessage : IRawMessage
    {
        private readonly IDictionary<string, string> _headers;
        private readonly string _body;

        public RawMessage(BasicDeliverEventArgs ea)
        {
            _headers = new Dictionary<string, string>();
            _body = Encoding.UTF8.GetString(ea.Body);

            if(ea.BasicProperties.Headers != null)
            {
                foreach(var header in ea.BasicProperties.Headers)
                {
                    _headers.Add(header.Key, Encoding.UTF8.GetString((byte[])header.Value));
                }
            }
        }

        public IDictionary<string, string> Headers => _headers;

        public string Body => _body;

        public string BusTechnology => "NServiceBus";
    }
}
