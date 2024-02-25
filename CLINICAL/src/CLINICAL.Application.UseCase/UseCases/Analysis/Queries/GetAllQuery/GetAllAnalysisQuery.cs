using CLINICAL.Application.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery
{
    /// <summary>
    /// Declaración del query y la implementación se realiza en un handler
    /// </summary>
    public class GetAllAnalysisQuery : IRequest<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
    }
}
