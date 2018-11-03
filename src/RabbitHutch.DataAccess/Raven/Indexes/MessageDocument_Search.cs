using System.Linq;
using RabbitHutch.Domain;
using Raven.Client.Documents.Indexes;

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
                        document.MessageId,
                        document.Headers.Select(x => x.Value),
                        document.ServiceBusTechnology
                    },
                    document.IsError,
                    document.ServiceBusTechnology,
                    document.MessageId,
                    document.ProcessedDateTime
                });

            Index(x => x.Any, FieldIndexing.Search);
        }
    }
}
