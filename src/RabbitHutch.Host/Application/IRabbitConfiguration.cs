using System.Collections.Generic;

namespace RabbitHutch.Host.Application
{
    public interface IRabbitConfiguration
    {
        string AppName { get; set; }
        string Host { get; set; }
        string AuditQueue { get; set; }
        string ErrorQueue { get; set; }
    }
}
