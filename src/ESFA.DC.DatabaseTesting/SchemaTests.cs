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

            string because = shouldExist ? "column [{0}] should be in [{1}]" : "column [{0}] should NOT be in [{1}]";

            foreach (IExpectedColumn column in expectedColumns)
            {
                IInformationSchema actualColumn = actualColumns.SingleOrDefault(x => x.COLUMN_NAME == column.ColumnName);
                if (shouldExist)
                {
                    actualColumn.Should().NotBeNull(because, column.ColumnName, columnNames);
                }
                else
                {
                    actualColumn.Should().BeNull(because, column.ColumnName, columnNames);
                }

                if (actualColumn == null)
                {
                    continue;
                }

                CheckColumnAttributes(actualColumn, column);
            }
        }

        public void AssertSpResultsColumnsExist(string schema, string procedureName, IEnumerable<IExpectedColumn> expectedColumns, bool shouldExist)
        {
            ISpResultset[] actualColumns = _dbConnnector.FirstResultSetForStoredProcedure(schema, procedureName).ToArray();
            actualColumns.Should().HaveCountGreaterThan(0, "there should be columns in the table");
            string columnNames = string.Join(", ", actualColumns.Select(x => x.NAME));

            string because = shouldExist ? "column [{0}] should be in [{1}] and have the correct matching attributes" : "column [{0}] should NOT be in [{1}]";

            foreach (var column in expectedColumns)
            {
                var actualColumn = actualColumns.SingleOrDefault(x => x.NAME == column.ColumnName);
                if (shouldExist)
                {
                    actualColumn.Should().NotBeNull(because, column.ColumnName, columnNames);
                }
                else
                {
                    actualColumn.Should().BeNull(because, column.ColumnName, columnNames);
                }

                if (actualColumn == null)
                {
                    continue;
                }

                CheckColumnAttributes(actualColumn, column);
            }
        }

        private void CheckColumnAttributes(IInformationSchema informationSchema, IExpectedColumn expectedColumn)
        {
            informationSchema.DATA_TYPE.Equals(expectedColumn.DataType, StringComparison.OrdinalIgnoreCase).Should().BeTrue("Column {0} should be data type {1} but is {2}", expectedColumn.ColumnName, expectedColumn.DataType, informationSchema.DATA_TYPE);
            informationSchema.IS_NULLABLE.Should().Be(expectedColumn.IsNullable ? "YES" : "NO", "Column {0} should{1}be nullable", expectedColumn.ColumnName, expectedColumn.IsNullable ? string.Empty : " not ");

            switch (informationSchema.DATA_TYPE.ToUpper())
            {
                case "CHAR":
                case "VARCHAR":
                case "NVARCHAR":
                    if (expectedColumn.CharacterMaximumLength > -1)
                    {
                        informationSchema.CHARACTER_MAXIMUM_LENGTH.Should().Be(
                            expectedColumn.CharacterMaximumLength,
                            "Column {0} should have a maximum length of {1}",
                            expectedColumn.ColumnName,
                            expectedColumn.CharacterMaximumLength);
                    }

                    break;
                case "DECIMAL":
                    informationSchema.NUMERIC_PRECISION.Should().Be(expectedColumn.NumericPrecision, "Column {0} should have a number precision of {1}", expectedColumn.ColumnName, expectedColumn.NumericPrecision);
                    informationSchema.NUMERIC_SCALE.Should().Be(expectedColumn.NumericScale, "Column {0} should have a number scale of {1}", expectedColumn.ColumnName, expectedColumn.NumericScale);
                    break;
                case "DATETIME":
                case "DATE":
                    informationSchema.DATETIME_PRECISION.Should().Be(expectedColumn.DatetimePrecision, "Column {0} should have a date time precision of {1}", expectedColumn.ColumnName, expectedColumn.DatetimePrecision);
                    break;
            }

            if (expectedColumn.OrdinalPosition > 0)
            {
                informationSchema.ORDINAL_POSITION.Should().Be(expectedColumn.OrdinalPosition, "Column {0} should have an ordinal position of {1}", expectedColumn.ColumnName, expectedColumn.OrdinalPosition);
            }
        }

        private void CheckColumnAttributes(ISpResultset sp, IExpectedColumn expectedColumn)
        {
            sp.Data_Type.Equals(expectedColumn.DataType, StringComparison.OrdinalIgnoreCase).Should().BeTrue("Column {0} should be data type {1} but is {2}", expectedColumn.ColumnName, expectedColumn.DataType, sp.Data_Type);

            switch (sp.Data_Type.ToUpper())
            {
                case "CHAR":
                case "VARCHAR":
                    sp.MAX_LENGTH.Should().Be(expectedColumn.CharacterMaximumLength, "Column {0} should have a maximum length of {1}", expectedColumn.ColumnName, expectedColumn.CharacterMaximumLength);
                    break;
                case "DECIMAL":
                    sp.PRECISION.Should().Be(expectedColumn.NumericPrecision, "Column {0} should have a precision of {1}", expectedColumn.ColumnName, expectedColumn.NumericPrecision);
                    sp.SCALE.Should().Be(expectedColumn.NumericScale, "Column {0} should have a scale of {1}", expectedColumn.ColumnName, expectedColumn.NumericScale);
                    break;
                case "DATE":
                    sp.PRECISION.Should().Be(expectedColumn.DatetimePrecision, "Column {0} should have a date time precision of {1}", expectedColumn.ColumnName, expectedColumn.DatetimePrecision);
                    break;
            }
        }
    }
}
