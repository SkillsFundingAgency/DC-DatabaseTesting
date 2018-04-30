using System;
using System.Collections.Generic;
using System.Linq;
using ESFA.DC.DatabaseTesting.Interface;
using ESFA.DC.DatabaseTesting.Model.Interface;
using FluentAssertions;

namespace ESFA.DC.DatabaseTesting
{
    public sealed class SchemaTests : ISchemaTests
    {
        private readonly IDbConnector _dbConnnector;

        public SchemaTests(IDbConnector dbConnnector)
        {
            _dbConnnector = dbConnnector;
        }

        public void AssertTableColumnsExist(string schema, string tableName, IEnumerable<IExpectedColumn> expectedColumns, bool shouldExist)
        {
            IInformationSchema[] actualColumns = _dbConnnector.QueryInformationSchemaColumns(schema, tableName).ToArray();
            actualColumns.Should().HaveCountGreaterThan(0, "there should be columns in the table");
            string columnNames = string.Join(", ", actualColumns.Select(x => x.COLUMN_NAME));

            string because = shouldExist ? "column [{0}] should be in [{1}] and have the correct matching attributes" : "column [{0}] should NOT be in [{1}]";

            foreach (var column in expectedColumns)
            {
                actualColumns.Any(c => BuildPredicate(c, column)).Should().Be(shouldExist, because, column.ColumnName, columnNames);
            }
        }

        public void AssertSpResultsColumnsExist(string schema, string procedureName, IEnumerable<IExpectedColumn> expectedColumns, bool shouldExist)
        {
            ISpResultset[] actualColumns = _dbConnnector.FirstResultSetForStoredProcedure(schema, procedureName).ToArray();

            string because = shouldExist ? "column [{0}] should be in [{1}] and have the correct matching attributes" : "column [{0}] should NOT be in [{1}]";

            foreach (var column in expectedColumns)
            {
                actualColumns.Any(c => BuildPredicate(c, column)).Should().Be(shouldExist, because, column.ColumnName);
            }
        }

        private bool BuildPredicate(IInformationSchema informationSchema, IExpectedColumn expectedColumn)
        {
            bool bReturn = informationSchema.DATA_TYPE.Equals(expectedColumn.DataType, StringComparison.OrdinalIgnoreCase);
            if (!bReturn)
            {
                return false;
            }

            switch (informationSchema.DATA_TYPE.ToUpper())
            {
                case "CHAR":
                case "VARCHAR":
                    bReturn = informationSchema.COLUMN_NAME == expectedColumn.ColumnName && informationSchema.CHARACTER_MAXIMUM_LENGTH == expectedColumn.CharacterMaximumLength && informationSchema.IS_NULLABLE == (expectedColumn.IsNullable ? "YES" : "NO");
                    break;
                case "DECIMAL":
                    bReturn = informationSchema.COLUMN_NAME == expectedColumn.ColumnName && informationSchema.NUMERIC_PRECISION == expectedColumn.NumericPrecision && informationSchema.NUMERIC_SCALE == expectedColumn.NumericScale && informationSchema.IS_NULLABLE == (expectedColumn.IsNullable ? "YES" : "NO");
                    break;
                case "DATE":
                    bReturn = informationSchema.COLUMN_NAME == expectedColumn.ColumnName && informationSchema.DATETIME_PRECISION == expectedColumn.DatetimePrecision && informationSchema.IS_NULLABLE == (expectedColumn.IsNullable ? "YES" : "NO");
                    break;
                default:
                    bReturn = informationSchema.COLUMN_NAME == expectedColumn.ColumnName && informationSchema.IS_NULLABLE == (expectedColumn.IsNullable ? "YES" : "NO");
                    break;
            }

            if (bReturn && expectedColumn.OrdinalPosition > 0)
            {
                bReturn = informationSchema.ORDINAL_POSITION == expectedColumn.OrdinalPosition;
            }

            return bReturn;
        }

        private bool BuildPredicate(ISpResultset sp, IExpectedColumn expectedColumn)
        {
            bool bReturn;
            switch (sp.Data_Type.ToUpper())
            {
                case "CHAR":
                case "VARCHAR":
                    bReturn = sp.NAME == expectedColumn.ColumnName && sp.MAX_LENGTH == expectedColumn.CharacterMaximumLength;
                    break;
                case "DECIMAL":
                    bReturn = sp.NAME == expectedColumn.ColumnName && sp.PRECISION == expectedColumn.NumericPrecision && sp.SCALE == expectedColumn.NumericScale;
                    break;
                case "DATE":
                    bReturn = sp.NAME == expectedColumn.ColumnName && sp.PRECISION == expectedColumn.DatetimePrecision;
                    break;
                default:
                    bReturn = sp.NAME == expectedColumn.ColumnName;
                    break;
            }

            return bReturn;
        }
    }
}
