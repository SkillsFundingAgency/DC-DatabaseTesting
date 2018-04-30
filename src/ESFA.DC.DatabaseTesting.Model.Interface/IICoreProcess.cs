using System;

namespace ESFA.DC.DatabaseTesting.Model.Interface
{
    public interface IICoreProcess
    {
        long Processor_Id { get; set; }

        int Processor_Status_Id { get; set; }

        string OriginalProcessorName { get; set; }

        string ProcessorName { get; set; }

        string CurrentLocation { get; set; }

        DateTime Date_Added { get; set; }

        bool Finished_Validation { get; set; }

        bool Had_Errors { get; set; }

        long Total_Errors { get; set; }

        long Total_Warnings { get; set; }

        string ProcessTime_In_Secs { get; set; }

        DateTime ProcessingStartedAt { get; set; }

        DateTime ProcessingEndedAt { get; set; }

        string ReportLocation { get; set; }

        string Data_Loaded_By { get; set; }

        DateTime Created_On { get; set; }

        string Created_By { get; set; }

        DateTime Modified_On { get; set; }

        string Modified_By { get; set; }

        int Processor_Type_Id { get; set; }

        string SystemMessage { get; set; }

        int Last_Status_Id { get; set; }

        int RecordsInProcessor { get; set; }

        int RecordsMerged { get; set; }

        int RecordsWithErrorsOnly { get; set; }

        int RecordsWithErrorsAndWarnings { get; set; }

        int RecordsWithWarningsOnly { get; set; }

        int RecordsWithNoIssues { get; set; }
    }
}
