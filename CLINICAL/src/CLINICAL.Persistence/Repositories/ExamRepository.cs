using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storeProcedure)
        {
            using var connection = _context.CreateConnection;
            var exams = await connection.QueryAsync<GetAllExamResponseDto>(storeProcedure, commandType: CommandType.StoredProcedure);
            return exams;
        }
    }
}
