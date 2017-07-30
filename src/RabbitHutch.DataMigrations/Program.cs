using Raven.Client.Document;
using RavenMigrations;

namespace RabbitHutch.DataMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            var store = new DocumentStore
            {
                Url = "http://localhost:8080/",
                DefaultDatabase = "RabbitHutch"
            }.Initialize();

            Runner.Run(store);
        }
    }
}
