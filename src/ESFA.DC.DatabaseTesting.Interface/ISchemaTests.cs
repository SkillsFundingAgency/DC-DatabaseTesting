using System.Collections.Generic;
using ESFA.DC.DatabaseTesting.Model.Interface;

namespace ESFA.DC.DatabaseTesting.Interface
{
    public interface ISchemaTests
    {
        void AssertTableColumnsExist(
            string schema,
            string tableName,
            IEnumerable<IExpectedColumn> expectedColumns,
            bool shouldExist);

        void AssertSpResultsColumnsExist(
            string schema,
            string procedureName,
            IEnumerable<IExpectedColumn> expectedColumns,
            bool shouldExist);
    }
}
