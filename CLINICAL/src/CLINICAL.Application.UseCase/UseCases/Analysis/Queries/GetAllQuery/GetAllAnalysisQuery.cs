using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery
{
    /// <summary>
    /// Declaración del query y la implementación se realiza en un handler
    /// </summary>
    public class GetAllAnalysisQuery : IRequest<BasePaginationResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
