using System.Collections.Generic;
using RabbitHutch.Domain;

namespace RabbitHutch.DataAccess.Raven
{
    public class RavenSearchResult : ISearchResult
    {
        public IEnumerable<MessageDocument> DocumentResults { get; set; }
        public int TotalResults { get; set; }
    }
}
