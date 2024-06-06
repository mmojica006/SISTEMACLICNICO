using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Persistence.Repositories
{
    /// <summary>
    /// Nos ayuda a unificar las transacciones atravez de repositorio generico
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Analysis> Analysis { get; }


        public UnitOfWork(IGenericRepository<Analysis> analysis)
        {
            Analysis = analysis;
        }

        /// <summary>
        /// Liberar los recursos no administrados utilizados por la misma clase
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
