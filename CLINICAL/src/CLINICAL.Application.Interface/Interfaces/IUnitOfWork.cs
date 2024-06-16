using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interfaces
{
    /// <summary>
    /// Representa una unidad de trabajo y se utiliza para agrupar multiple  operaciones de acceso a datos en una unica transaction
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Especificando que puedo acceder directamente a las operaciones de acceso a datos especificamente para mi 
        /// identidad Analysis mediante el repositorio generico
        /// </summary>
        IGenericRepository<Analysis> Analysis { get; }
        IGenericRepository<Exam> Exam { get; }
    }
}
