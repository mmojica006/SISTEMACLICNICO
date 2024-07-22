using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;

namespace CLINICAL.Persistence.Repositories
{
    /// <summary>
    /// Nos ayuda a unificar las transacciones atravez de repositorio generico
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Analysis> Analysis { get; }

        public IExamRepository Exam { get; }

        public UnitOfWork(ApplicationDbContext context, IGenericRepository<Analysis> analysis)
        {
            _context = context;
            Analysis = analysis;
            Exam = new ExamRepository(context);

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
