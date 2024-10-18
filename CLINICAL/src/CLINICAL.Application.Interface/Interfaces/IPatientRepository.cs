using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interfaces
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
        /// <summary>
        /// Definición de la interface
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <returns></returns>
        Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatients(string storedProcedure);
    }
}
