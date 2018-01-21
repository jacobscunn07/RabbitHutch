using System.Linq;
using RabbitHutch.Domain;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace RabbitHutch.DataAccess.Raven.Indexes
{
    public class MessageDocument_Search : AbstractIndexCreationTask<MessageDocument>
    {
        public MessageDocument_Search()
        {
            Map = messageDocuments => messageDocuments.Select(document =>
                new
                {
                    Any = new object[]
                    {
                        document.ApplicationId,
                        document.Body,
                        document.DocId,
                        document.Headers.Select(x => x.Value),
                        document.ServiceBusTechnology
                    },
                    document.DocId,
                    document.IsError,
                    document.ServiceBusTechnology,
                    document.MessageId,
                    document.ProcessedDateTime
                });

            Sort(x => x.ProcessedDateTime, SortOptions.Long);
            Index(x => x.Any, FieldIndexing.Analyzed);
            Analyzers.Add(x => x.Any, "StandardAnalyzer");
        }
    }
}
