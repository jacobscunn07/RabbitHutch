﻿using RabbitHutch.Host.Application.Interfaces;

namespace RabbitHutch.Host.Application
{
    public class RabbitConfiguration : IRabbitConfiguration
    {
        public RabbitConfiguration()
        {
            ApplicationName = "Local";
            Host = "localhost";
            AuditQueue = "audit";
            ErrorQueue = "error";
        }

        public string ApplicationName { get; set; }
        public string Host { get; set; }
        public string AuditQueue { get; set; }
        public string ErrorQueue { get; set; }
    }
}
