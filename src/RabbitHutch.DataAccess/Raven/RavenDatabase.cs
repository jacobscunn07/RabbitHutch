using System.Linq;
using RabbitHutch.DataAccess.Raven.Indexes;
using RabbitHutch.Domain;
using Raven.Client;

namespace RabbitHutch.DataAccess.Raven
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

        public ISearchResult Search(string query, int pageIndex, int pageSize)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Advanced.MaxNumberOfRequestsPerSession = int.MaxValue;

                var docs = session
                    .Advanced
                    .DocumentQuery<MessageDocument, MessageDocument_Search>()
                    .Statistics(out RavenQueryStatistics stats)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .Where(query)
                    .ToList();

                return new RavenSearchResult
                {
                    DocumentResults = docs,
                    TotalResults = stats.TotalResults
                };
            }
        }
    }
}
