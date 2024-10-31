using CLINICAL.Application.Dtos.TakeExam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class TakeExamRepository : GenericRepository<TakeExam>, ITakeExamRepository
    {
        private readonly ApplicationDbContext _context;
        public TakeExamRepository(ApplicationDbContext context) : base(context) //hace referencia a la instancia del generic
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllTakeExamResponseDto>> GetAllTakeExams(string storeProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var exams = await connection
                .QueryAsync<GetAllTakeExamResponseDto>(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return exams;
        }
    }
}
