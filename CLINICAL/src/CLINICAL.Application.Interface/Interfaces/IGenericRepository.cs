namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string storeProcedure);
        Task<IEnumerable<T>> GetAllWithPaginationAsync(string storeProcedure, object parameter);
        Task<T> GetByIdAsync(string storeProcedure, object parameter);
        Task<bool> ExecAsync(string storeProcedure, object parameter);
        Task<int> CountAsync(string tableName);

    }
}
