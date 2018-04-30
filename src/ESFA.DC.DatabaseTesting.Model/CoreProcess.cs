using System;
using ESFA.DC.DatabaseTesting.Model.Interface;

namespace ESFA.DC.DatabaseTesting.Model
{
    public sealed class CoreProcess : IICoreProcess
    {
        public long Processor_Id { get; set; }

        public int Processor_Status_Id { get; set; }

        public string OriginalProcessorName { get; set; }

        public string ProcessorName { get; set; }

        public string CurrentLocation { get; set; }

        public DateTime Date_Added { get; set; }

        public bool Finished_Validation { get; set; }

        public bool Had_Errors { get; set; }

        public long Total_Errors { get; set; }

        public long Total_Warnings { get; set; }

        public string ProcessTime_In_Secs { get; set; }

        public DateTime ProcessingStartedAt { get; set; }

        public DateTime ProcessingEndedAt { get; set; }

        public string ReportLocation { get; set; }

        public string Data_Loaded_By { get; set; }

        public DateTime Created_On { get; set; }

        public string Created_By { get; set; }

        public DateTime Modified_On { get; set; }

        public string Modified_By { get; set; }

        public int Processor_Type_Id { get; set; }

        public string SystemMessage { get; set; }

        public int Last_Status_Id { get; set; }

        public int RecordsInProcessor { get; set; }

        public int RecordsMerged { get; set; }

        public int RecordsWithErrorsOnly { get; set; }

        public int RecordsWithErrorsAndWarnings { get; set; }

        public int RecordsWithWarningsOnly { get; set; }

        public int RecordsWithNoIssues { get; set; }
    }
}
