using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.ChangestateCommand
{
    public class ChangeStateExamCommand: IRequest<BaseResponse<bool>>
    {
        public int ExamId { get; set; }
        public int State { get; set; }
    }
}
