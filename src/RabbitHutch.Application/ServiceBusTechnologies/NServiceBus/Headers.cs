namespace RabbitHutch.Application.ServiceBusTechnologies.NServiceBus
{
    public static class Headers
    {
        public const string MessageId = "NServiceBus.MessageId";
        public const string EnclosedMessageTypes = "NServiceBus.EnclosedMessageTypes";
        public const string OriginatingEndPoint = "NServiceBus.OriginatingEndpoint";
	    public const string ProcessingEndPoint = "NServiceBus.ProcessingEndpoint";
	    public const string ProcessingDateTimeEnded = "NServiceBus.ProcessingEnded";
        public const string ExceptionMessage = "NServiceBus.ExceptionInfo.Message";
        public const string StackStrace = "NServiceBus.ExceptionInfo.StackTrace";
        public const string FailedQ = "NServiceBus.FailedQ";
        public const string TimeOfFailure = "NServiceBus.TimeOfFailure";
        public const string IsReplay = "RabbitHutch.IsReplay";
        public const string ReplayDateTime = "RabbitHutch.ReplayDateTime";
    }
}
