using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using ESFA.DC.DatabaseTesting.Interface;
using ESFA.DC.DatabaseTesting.Model;
using ESFA.DC.DatabaseTesting.Model.Interface;

namespace ESFA.DC.DatabaseTesting
{
    public sealed class DbConnector : IDbConnector
    {
        private readonly IDbConnectorConfiguration _dbConnectorConfiguration;

        public DbConnector(IDbConnectorConfiguration dbConnectorConfiguration)
        {
            _dbConnectorConfiguration = dbConnectorConfiguration;
        }

        public IEnumerable<IInformationSchema> QueryInformationSchemaColumns(string schemaName, string tableName)
        {
            using (var sqlConnection = new SqlConnection(_dbConnectorConfiguration.ConnectionString))
            {
                return sqlConnection.Query<InformationSchema>(string.Format(Resources.Schema, schemaName, tableName));
            }
        }

        public IEnumerable<ISpResultset> FirstResultSetForStoredProcedure(string schemaName, string procedureName)
        {
            using (var sqlConnection = new SqlConnection(_dbConnectorConfiguration.ConnectionString))
            {
                return sqlConnection.Query<SpResultset>(string.Format(Resources.StoredProcedure, schemaName, procedureName));
            }
        }
    }
}
