namespace RabbitHutch.Application.ServiceBusTechnologies.MassTransit
{
    public static class Headers
    {
        public const string MessageId = "MT-MessageId";
        public const string EnclosedMessageTypes = "MT-*";
        public const string OriginatingEndPoint = "MT-OriginatingEndpoint";
        public const string ProcessingEndPoint = "MT-ProcessingEndpoint";
        public const string ProcessingDateTimeEnded = "MT-Fault-Timestamp";
        public const string ExceptionMessage = "MT-Fault-Message";
        public const string StackStrace = "MT-Fault-StackTrace";
        public const string FailedQ = "MT-ProcessingEndpoint";
        public const string TimeOfFailure = "MT-Fault-Timestamp";
        public const string IsReplay = "RabbitHutch.IsReplay";
        public const string ReplayDateTime = "RabbitHutch.ReplayDateTime";
    }
}
