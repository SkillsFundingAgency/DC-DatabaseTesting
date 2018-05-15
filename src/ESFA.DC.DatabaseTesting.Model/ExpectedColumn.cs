using ESFA.DC.DatabaseTesting.Model.Interface;

namespace ESFA.DC.DatabaseTesting.Model
{
    public sealed class ExpectedColumn : IExpectedColumn
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpectedColumn"/> class.
        /// Use this constructor, or one of the static helper methods to create an instance of an expected column.
        /// </summary>
        /// <param name="columnName"><see cref="IExpectedColumn.ColumnName"/></param>
        /// <param name="dataType"><see cref="IExpectedColumn.DataType"/></param>
        /// <param name="isNullable"><see cref="IExpectedColumn.IsNullable"/></param>
        /// <param name="ordinalPosition"><see cref="IExpectedColumn.OrdinalPosition"/></param>
        /// <param name="characterMaximumLength"><see cref="IExpectedColumn.CharacterMaximumLength"/></param>
        /// <param name="numericPrecision"><see cref="IExpectedColumn.NumericPrecision"/></param>
        /// <param name="numericScale"><see cref="IExpectedColumn.NumericScale"/></param>
        /// <param name="datetimePrecision"><see cref="IExpectedColumn.DatetimePrecision"/></param>
        public ExpectedColumn(string columnName, string dataType, bool isNullable, int ordinalPosition = -1, int characterMaximumLength = -1, int numericPrecision = -1, int numericScale = -1, int datetimePrecision = -1)
        {
            ColumnName = columnName;
            DataType = dataType;
            IsNullable = isNullable;
            OrdinalPosition = ordinalPosition;
            CharacterMaximumLength = characterMaximumLength;
            NumericPrecision = numericPrecision;
            NumericScale = numericScale;
            DatetimePrecision = datetimePrecision;
        }

        private ExpectedColumn()
        {
        }

        /// <summary>
        /// <see cref="IExpectedColumn.ColumnName"/>
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// <see cref="IExpectedColumn.OrdinalPosition"/>
        /// </summary>
        public int OrdinalPosition { get; set; }

        /// <summary>
        /// <see cref="IExpectedColumn.IsNullable"/>
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// <see cref="IExpectedColumn.DataType"/>
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// <see cref="IExpectedColumn.CharacterMaximumLength"/>
        /// </summary>
        public int CharacterMaximumLength { get; set; }

        /// <summary>
        /// <see cref="IExpectedColumn.NumericPrecision"/>
        /// </summary>
        public int NumericPrecision { get; set; }

        /// <summary>
        /// <see cref="IExpectedColumn.NumericScale"/>
        /// </summary>
        public int NumericScale { get; set; }

        /// <summary>
        /// <see cref="IExpectedColumn.DatetimePrecision"/>
        /// </summary>
        public int DatetimePrecision { get; set; }

        public static ExpectedColumn CreateBigInt(string columnNameBigInt, int ordinalPosition, bool nullable)
        {
            return new ExpectedColumn
            {
                OrdinalPosition = ordinalPosition,
                ColumnName = columnNameBigInt,
                DataType = "bigint",
                NumericPrecision = 19,
                NumericScale = 0,
                IsNullable = nullable
            };
        }

        public static ExpectedColumn CreateInt(string columnNameInt, int ordinalPosition, bool nullable)
        {
            return new ExpectedColumn
            {
                OrdinalPosition = ordinalPosition,
                ColumnName = columnNameInt,
                DataType = "int",
                NumericPrecision = 10,
                NumericScale = 0,
                IsNullable = nullable
            };
        }

        public static ExpectedColumn CreateNvarChar(string columnNameNvarChar, int ordinalPosition, bool nullable, int characterMaximumLength = -1)
        {
            return new ExpectedColumn
            {
                OrdinalPosition = ordinalPosition,
                CharacterMaximumLength = characterMaximumLength,
                ColumnName = columnNameNvarChar,
                DataType = "nvarchar",
                IsNullable = nullable
            };
        }

        public static ExpectedColumn CreateVarChar(string columnNameVarChar, int ordinalPosition, bool nullable, int characterMaximumLength = -1)
        {
            return new ExpectedColumn
            {
                OrdinalPosition = ordinalPosition,
                CharacterMaximumLength = characterMaximumLength,
                ColumnName = columnNameVarChar,
                DataType = "varchar",
                IsNullable = nullable
            };
        }

        public static ExpectedColumn CreateBit(string columnNameBit, int ordinalPosition, bool nullable)
        {
            return new ExpectedColumn
            {
                OrdinalPosition = ordinalPosition,
                ColumnName = columnNameBit,
                DataType = "bit",
                IsNullable = nullable
            };
        }

        public static ExpectedColumn CreateDecimal(string columnNameDecimal, int ordinalPosition, bool nullable, int numericPrecision = 18, int numericScale = 0)
        {
            return new ExpectedColumn
            {
                OrdinalPosition = ordinalPosition,
                ColumnName = columnNameDecimal,
                DataType = "decimal",
                NumericPrecision = numericPrecision,
                NumericScale = numericScale,
                IsNullable = nullable
            };
        }

        public static ExpectedColumn CreateDateTime(string columnNameDateTime, int ordinalPosition, bool nullable)
        {
            return new ExpectedColumn
            {
                OrdinalPosition = ordinalPosition,
                ColumnName = columnNameDateTime,
                DataType = "datetime",
                DatetimePrecision = 3,
                IsNullable = nullable
            };
        }

        public static ExpectedColumn CreateDate(string columnNameDate, int ordinalPosition, bool nullable)
        {
            return new ExpectedColumn
            {
                OrdinalPosition = ordinalPosition,
                ColumnName = columnNameDate,
                DataType = "date",
                DatetimePrecision = 0,
                IsNullable = nullable
            };
        }
    }
}
