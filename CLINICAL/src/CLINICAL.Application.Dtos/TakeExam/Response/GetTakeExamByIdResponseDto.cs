namespace CLINICAL.Application.Dtos.TakeExam.Response
{
    public class GetTakeExamByIdResponseDto
    {
        public int TakeExamId { get; set; }
        public int PatientId { get; set; }
        public int MedicId { get; set; }
        public IEnumerable<GetTakeexamDetailByTakeexamIdResponseDto>? TAkeExamDetails { get; set; }
    }

    public class GetTakeexamDetailByTakeexamIdResponseDto
    {
        public int TakeExamDetailId { get; set; }
        public int TakeExamId { get; set; }
        public int ExamId { get; set; }
        public int AnalysisId { get; set; }

    }
}
