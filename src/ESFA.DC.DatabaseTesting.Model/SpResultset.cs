using ESFA.DC.DatabaseTesting.Model.Interface;

namespace ESFA.DC.DatabaseTesting.Model
{
    public sealed class SpResultset : ISpResultset
    {
        public string NAME { get; set; }

        public int IS_NULLABLE { get; set; }

        public string SYSTEM_TYPE_NAME { get; set; }

        public string Data_Type { get; set; }

        public int MAX_LENGTH { get; set; }

        public int PRECISION { get; set; }

        public int SCALE { get; set; }
    }
}
