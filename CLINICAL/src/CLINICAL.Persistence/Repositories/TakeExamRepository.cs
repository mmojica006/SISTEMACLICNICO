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

        public async Task<TakeExam> GetTakeExamById(int takeExamId)
        {
            using var connection = _context.CreateConnection;
            var sql = @"SELECT TakeExamId, PatientId, MedicId FROM TakeExam where TakeExamId= @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);
            var takeExam = await connection.QuerySingleOrDefaultAsync<TakeExam>(sql, param: parameters);
            return takeExam!;

        }

        public async Task<IEnumerable<TakeExamDetail>> GetTakeExamDetailByTakeExamId(int takeExamId)
        {
            using var connection = _context.CreateConnection;
            var sql = @"SELECT TakeExamDetailId, TakeExamId, AnalysisId FROM TakeExamDetail where TakeExamId= @TakeExamId";
            var parameters = new DynamicParameters();
            parameters.Add("TakeExamId", takeExamId);
            var takeExamDetail = await connection.QueryAsync<TakeExamDetail>(sql, param: parameters);
            return takeExamDetail!;
        }
    }
}
