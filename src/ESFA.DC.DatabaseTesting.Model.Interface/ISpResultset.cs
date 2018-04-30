namespace ESFA.DC.DatabaseTesting.Model.Interface
{
    public interface ISpResultset
    {
        string NAME { get; set; }

        int IS_NULLABLE { get; set; }

        string SYSTEM_TYPE_NAME { get; set; }

        string Data_Type { get; set; }

        int MAX_LENGTH { get; set; }

        int PRECISION { get; set; }

        int SCALE { get; set; }
    }
}
