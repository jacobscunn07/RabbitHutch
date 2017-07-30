using RabbitHutch.Host.Domain;
using Raven.Client;

namespace RabbitHutch.Host.DataAccess
{
    public class RavenDatabase : IDatabase
    {
        private readonly IDocumentStore _documentStore;

        public RavenDatabase(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public bool Insert(MessageDocument document)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(document);
                session.SaveChanges();
                return document.Id != default(long);
            }
        }
    }
}
