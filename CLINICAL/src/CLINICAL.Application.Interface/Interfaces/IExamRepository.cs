using CLINICAL.Application.Dtos.Exam.Response;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IExamRepository
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storeProcedure);
    }
}
