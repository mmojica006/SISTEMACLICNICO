using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storeProcedure)
        {
            using var connection = _context.CreateConnection;
            return await connection.QueryAsync<T>(storeProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storeProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await connection.QuerySingleOrDefaultAsync<T>(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);

        }
        public async Task<bool> ExecAsync(string storeProcedure, object parameter)
        {
            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            var recordAffected = await connection.ExecuteAsync(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
            return recordAffected > 0;
        }


        public async Task<IEnumerable<T>> GetAllWithPaginationAsync(string storeProcedure, object parameter)
        {

            using var connection = _context.CreateConnection;
            var objParam = new DynamicParameters(parameter);
            return await connection.QueryAsync<T>(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// contar los registros de una tabla específica
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public async Task<int> CountAsync(string tableName)
        {
            using var connection = _context.CreateConnection;
            var query = $"SELECT COUNT(1) FROM {tableName}";
            var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;

        }
    }
}
