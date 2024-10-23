﻿using AutoMapper;
using CLINICAL.Application.Dtos.Patient.Response;
using CLINICAL.Application.UseCase.UseCases.Patient.Commands.CreateCommand;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<Patient, GetPatientByIdResponseDto>().ReverseMap();
            CreateMap<CreatePatientCommand, Patient>();
        }
    }
}