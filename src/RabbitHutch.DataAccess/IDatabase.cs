using RabbitHutch.Domain;

namespace RabbitHutch.DataAccess
{
    public interface IDatabase
    {
        bool Insert(MessageDocument document);

        ISearchResult Search(string query, int pageIndex, int pageSize);
    }
}
