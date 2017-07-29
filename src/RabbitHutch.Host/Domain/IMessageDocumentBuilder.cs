using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitHutch.Host.Domain
{
    public interface IMessageHeaders
    {
        IMessageBody WithHeaders(Dictionary<string, string> headers);
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
    }
}
