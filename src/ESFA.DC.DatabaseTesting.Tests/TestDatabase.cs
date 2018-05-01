using System.Configuration;
using ESFA.DC.DatabaseTesting.Interface;
using ESFA.DC.DatabaseTesting.Model;
using ESFA.DC.DatabaseTesting.Model.Interface;
using Xunit;

namespace ESFA.DC.DatabaseTesting.Tests
{
    public class TestDatabase
    {
        [Fact]
        public void TestSchema()
        {
            IDbConnectorConfiguration dbConnectorConfiguration = new DbConnectorConfiguration(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            IDbConnector dbConnector = new DbConnector(dbConnectorConfiguration);
            ISchemaTests schemaTests = new SchemaTests(dbConnector);

            IExpectedColumn[] expectedColumns =
            {
                ExpectedColumn.CreateBigInt("ID", 1, false),
                ExpectedColumn.CreateInt("anInt", 2, false),
                ExpectedColumn.CreateNvarChar("aString", 3, false),
                ExpectedColumn.CreateBit("aBool", 4, false),
                ExpectedColumn.CreateDecimal("aDecimal", 5, false),
                ExpectedColumn.CreateDateTime("aDateTime", 6, false)
            };
            schemaTests.AssertTableColumnsExist("dbo", "TestTable", expectedColumns, true);
        }
    }
}
