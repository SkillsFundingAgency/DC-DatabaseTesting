namespace ESFA.DC.DatabaseTesting.Model.Interface
{
    public interface IInformationSchema
    {
        string TABLE_CATALOG { get; set; }

        string TABLE_SCHEMA { get; set; }

        string TABLE_NAME { get; set; }

        string COLUMN_NAME { get; set; }

        int ORDINAL_POSITION { get; set; }

        string COLUMN_DEFAULT { get; set; }

        string IS_NULLABLE { get; set; }

        string DATA_TYPE { get; set; }

        int CHARACTER_MAXIMUM_LENGTH { get; set; }

        int CHARACTER_OCTET_LENGTH { get; set; }

        int NUMERIC_PRECISION { get; set; }

        int NUMERIC_PRECISION_RADIX { get; set; }

        int NUMERIC_SCALE { get; set; }

        int DATETIME_PRECISION { get; set; }

        string CHARACTER_SET_CATALOG { get; set; }

        string CHARACTER_SET_SCHEMA { get; set; }

        string CHARACTER_SET_NAME { get; set; }

        string COLLATION_CATALOG { get; set; }

        string COLLATION_SCHEMA { get; set; }

        string COLLATION_NAME { get; set; }

        string DOMAIN_CATALOG { get; set; }

        string DOMAIN_SCHEMA { get; set; }

        string DOMAIN_NAME { get; set; }
    }
}
