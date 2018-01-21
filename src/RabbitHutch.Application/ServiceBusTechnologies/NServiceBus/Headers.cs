namespace RabbitHutch.Application.ServiceBusTechnologies.NServiceBus
{
    public static class Headers
    {
        public const string MessageId = "NServiceBus.MessageId";
        public const string CorrelationId = "NServiceBus.CorrelationId";
        public const string TimeSent = "NServiceBus.TimeSent";
        public const string ContentType = "NServiceBus.ContentType";
        public const string EnclosedMessageTypes = "NServiceBus.EnclosedMessageTypes";
        public const string RelatedTo = "NServiceBus.RelatedTo";
        public const string ConversationId = "NServiceBus.ConversationId";
        public const string OriginatingEndPoint = "NServiceBus.OriginatingEndpoint";
	    public const string ProcessingEndPoint = "NServiceBus.ProcessingEndpoint";
	    public const string ProcessingDateTimeStarted = "NServiceBus.ProcessingStarted";
	    public const string ProcessingDateTimeEnded = "NServiceBus.ProcessingEnded";
        public const string ReplyTo = "NServiceBus.ReplyToAddress";
		public const string ExceptionType = "NServiceBus.ExceptionInfo.ExceptionType";
        public const string ExceptionMessage = "NServiceBus.ExceptionInfo.Message";
        public const string StackStrace = "NServiceBus.ExceptionInfo.StackTrace";
        public const string FailedQ = "NServiceBus.FailedQ";
        public const string TimeOfFailure = "NServiceBus.TimeOfFailure";
        public const string IsReplay = "RabbitHutch.IsReplay";
        public const string ReplayDateTime = "RabbitHutch.ReplayDateTime";
    }
}
