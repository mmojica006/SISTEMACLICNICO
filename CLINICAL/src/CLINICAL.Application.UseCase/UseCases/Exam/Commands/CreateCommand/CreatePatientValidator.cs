using CLINICAL.Application.UseCase.UseCases.Patient.Commands.CreateCommand;
using FluentValidation;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.Names).NotNull().WithMessage("El campo Nombres no puede ser nulos")
                .NotEmpty().WithMessage("El campo Nombre no puede ser vacío");

            RuleFor(x => x.LastName).NotNull().WithMessage("El campo Apellido Paterno no puede ser nulos")
               .NotEmpty().WithMessage("El campo Apellido Paterno no puede ser vacío");

            RuleFor(x => x.MotherMaidenName).NotNull().WithMessage("El campo Apellido Materno no puede ser nulos")
               .NotEmpty().WithMessage("El campo Apellido Materno no puede ser vacío");

            RuleFor(x => x.DocumentNumber).NotNull().WithMessage("El campo Número  Documento no puede ser nulos")
               .NotEmpty().WithMessage("El campo Número  Documento no puede ser vacío")
               .Must(BeNumeric!).WithMessage("El campo Número documento debe contener solo números");


            RuleFor(x => x.Phone).NotNull().WithMessage("El campo Teléfono no puede ser nulos")
               .NotEmpty().WithMessage("El campo Teléfono no puede ser vacío")
               .Must(BeNumeric!).WithMessage("El campo Teléfono debe contener solo números");
        }

        private bool BeNumeric(string input)
        {
            return int.TryParse(input, out _);
        }
    }
}
