using AutoMapper;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;
        public DeleteAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                response.Data = await _analysisRepository.AnalysisRemove(request.AnalysisId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa!!!";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;

            }
            return response;
        }
    }
}
