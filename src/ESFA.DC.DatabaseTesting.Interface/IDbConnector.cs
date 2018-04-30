using System.Collections.Generic;
using ESFA.DC.DatabaseTesting.Model.Interface;

namespace ESFA.DC.DatabaseTesting.Interface
{
    public interface IDbConnector
    {
        IEnumerable<IInformationSchema> QueryInformationSchemaColumns(string schemaName, string tableName);

        IEnumerable<ISpResultset> FirstResultSetForStoredProcedure(string schemaName, string procedureName);
    }
}
