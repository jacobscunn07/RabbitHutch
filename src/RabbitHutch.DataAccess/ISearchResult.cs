using System.Collections.Generic;
using RabbitHutch.Domain;

namespace RabbitHutch.DataAccess
{
    public interface ISearchResult
    {
        IEnumerable<MessageDocument> DocumentResults { get; set; }
        int TotalResults { get; set; }
    }
}
