using RabbitHutch.Host.DataAccess.Raven.Indexes;
using RavenMigrations;

namespace RabbitHutch.DataMigrations.Migrations
{
    [Migration(2017073001)]
    public class Migration_2017073001_MessageSearchIndex : Migration
    {
        public override void Up()
        {
            var index = new MessageDocument_Search();
            index.Execute(DocumentStore);
        }
    }
}
