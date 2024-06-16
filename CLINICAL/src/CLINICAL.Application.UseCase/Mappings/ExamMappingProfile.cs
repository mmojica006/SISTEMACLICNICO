using AutoMapper;
using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class ExamMappingProfile : Profile
    {
        public ExamMappingProfile()
        {
            CreateMap<Exam, GetExamByIdResponseDto>().ReverseMap();
        }
    }
}
