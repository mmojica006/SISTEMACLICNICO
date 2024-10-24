using AutoMapper;
using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.Dtos.Medic;
using CLINICAL.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class MedicMappingProfile : Profile
    {
        public MedicMappingProfile()
        {
            CreateMap<Medic, GetMedicByIdResponseDto>().ReverseMap();
            CreateMap<CreateMedicCommand, Medic>();

        }
    }
}
