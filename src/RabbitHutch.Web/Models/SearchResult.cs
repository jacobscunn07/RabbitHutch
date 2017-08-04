using System.Collections.Generic;

namespace RabbitHutch.Web.Models
{
    public class SearchResult
    {
        public int TotalResults { get; set; }
        public IEnumerable<SearchMessageResult> Results { get; set; }

        public class SearchMessageResult
        {
            public long DocId { get; set; }
            public string MessageId { get; set; }
            public string Body { get; set; }
            public bool IsError { get; set; }
            public string ProcessedEndpoint { get; set; }
        }
    }
}