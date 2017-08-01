using System.Collections.Generic;

namespace RabbitHutch.Host.Domain.Interfaces
{
    public interface IRawMessage
    {
        IDictionary<string, string> Headers { get; }
        string Body { get; }
        string BusTechnology { get; }
    }
}
