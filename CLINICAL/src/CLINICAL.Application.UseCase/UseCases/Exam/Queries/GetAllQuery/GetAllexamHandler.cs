using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetAllQuery
{
    public class GetAllexamHandler : IRequestHandler<GetAllExamQuery, BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllexamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {

            var response = new BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>();

            try 
            {
                var count = await _unitOfWork.Exam.CountAsync(TB.Exams);

                var exams = await _unitOfWork.Exam.GetAllExams(SP.uspExamList, request);

                if (exams is not null) 
                {
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Data = exams;
                    response.Message = GlobalMessages.MESSAGE_QUERY;
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
