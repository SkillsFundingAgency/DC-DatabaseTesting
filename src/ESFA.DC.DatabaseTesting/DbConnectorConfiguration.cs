using ESFA.DC.DatabaseTesting.Interface;

namespace ESFA.DC.DatabaseTesting
{
    public sealed class DbConnectorConfiguration : IDbConnectorConfiguration
    {
        public DbConnectorConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
