namespace ESFA.DC.DatabaseTesting.Model.Interface
{
    public interface IExpectedColumn
    {
        /// <summary>
        /// Gets or sets the Column Name.
        /// </summary>
        string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets the Ordinal Position. Set to -1 to skip this check.
        /// </summary>
        int OrdinalPosition { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the column is nullable.
        /// </summary>
        bool IsNullable { get; set; }

        /// <summary>
        /// Gets or sets the columns data type.
        /// </summary>
        string DataType { get; set; }

        /// <summary>
        /// Gets or sets the number of characters in a string column.
        /// </summary>
        int CharacterMaximumLength { get; set; }

        /// <summary>
        /// Gets or sets the numeric precision of a numeric column.
        /// </summary>
        int NumericPrecision { get; set; }

        /// <summary>
        /// Gets or sets the numeric scale value of a numeric column.
        /// </summary>
        int NumericScale { get; set; }

        /// <summary>
        /// Gets or sets the date & time precision of a date time column.
        /// </summary>
        int DatetimePrecision { get; set; }
    }
}
