using AutoMapper;
using CLINICAL.Application.Dtos.TakeExam.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class TakeExamMappingProfile : Profile
    {
        public TakeExamMappingProfile()
        {
            
            CreateMap<GetTakeExamByIdResponseDto, TakeExam>().ReverseMap();

            CreateMap<GetTakeexamDetailByTakeexamIdResponseDto, TakeExamDetail>().ReverseMap();
        }
    }
}
