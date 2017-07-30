using RabbitHutch.Host.Domain;

namespace RabbitHutch.Host.DataAccess
{
    public interface IDatabase
    {
        bool Insert(MessageDocument document);
    }
}
