namespace RabbitHutch.Host.Application.Interfaces
{
    public interface IRabbitConfiguration
    {
        string AppName { get; set; }
        string Host { get; set; }
        string AuditQueue { get; set; }
        string ErrorQueue { get; set; }
    }
}
