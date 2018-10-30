using System.Linq;
using RabbitHutch.DataAccess.Raven.Indexes;
using RabbitHutch.Domain;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

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
                return !string.IsNullOrEmpty(document.Id);
            }
        }

        public ISearchResult Search(string query, int pageIndex, int pageSize)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Advanced.MaxNumberOfRequestsPerSession = int.MaxValue;

                var docs = session
                    //.Advanced
                    .Query<MessageDocument, MessageDocument_Search>()
                    .Search(x => x.Any, query)
                    //.Statistics(out RavenQueryStatistics stats)
                    .OrderByDescending(x => x.DocId)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new RavenSearchResult
                {
                    DocumentResults = docs,
                    //TotalResults = stats.TotalResults
                };
            }
        }
    }
}
