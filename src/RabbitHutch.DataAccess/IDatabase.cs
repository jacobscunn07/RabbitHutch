using RabbitHutch.Domain;

namespace RabbitHutch.DataAccess
{
    public interface IDatabase
    {
        bool Insert(MessageDocument document);
    }
}
