using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamvALIDATOR : AbstractValidator<CreateExamCommand>
    {
        public CreateExamvALIDATOR()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("El campo Nombre no puede ser nulo")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío");

        }
    }
}
