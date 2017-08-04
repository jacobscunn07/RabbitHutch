namespace RabbitHutch.Application.Interfaces
{
    public interface IRabbitConfiguration
    {
        string ApplicationName { get; set; }
        string Host { get; set; }
        string AuditQueue { get; set; }
        string ErrorQueue { get; set; }
    }
}
