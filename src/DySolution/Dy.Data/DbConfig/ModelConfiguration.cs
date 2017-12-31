

namespace Dy.Data.DbConfig
{
    public class ModelConfiguration : DbConfiguration
    {
        public ModelConfiguration()
        {

            var conn = System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionConst.DefaultConnectionKey];
            var connProvder = conn.ProviderName;

            this.SetHistoryContext(connProvder, (connection, defaultSchema) => new MigrationContext(connection, defaultSchema));
        }
    }
}
