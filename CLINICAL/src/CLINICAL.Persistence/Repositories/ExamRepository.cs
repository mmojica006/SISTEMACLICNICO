﻿using CLINICAL.Application.Dtos.Exam.Response;
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
        public ExamRepository(ApplicationDbContext context): base(context) //hace referencia a la instancia del generic
        {
            _context = context;
        }
        public async Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storeProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var exams = await connection
                .QueryAsync<GetAllExamResponseDto>(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return exams;
        }
    }
}
