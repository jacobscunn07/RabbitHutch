using RabbitHutch.Host.Domain;
using Raven.Client;
using Raven.Client.Document;

namespace RabbitHutch.Host.DataAccess
{
    public class RavenDatabase : IDatabase
    {
        public bool Insert(MessageDocument document)
        {
            using (IDocumentStore store = new DocumentStore
            {
                Url = "http://localhost:8080/",
                DefaultDatabase = "RabbitHutch"
            })
            {
                store.Initialize();

                using (IDocumentSession session = store.OpenSession())
                {
                    session.Store(document);
                    session.SaveChanges();
                    return document.Id != default(long);
                }
            }
        }
    }
}
