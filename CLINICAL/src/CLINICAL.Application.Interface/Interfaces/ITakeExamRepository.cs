using CLINICAL.Application.Dtos.TakeExam.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface ITakeExamRepository : IGenericRepository<TakeExam>
    {
        Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExams(string storeProcedure, object parameter);
        Task<TakeExam> GetTakeExamById(int takeExamId);
        Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId);
    }
}
