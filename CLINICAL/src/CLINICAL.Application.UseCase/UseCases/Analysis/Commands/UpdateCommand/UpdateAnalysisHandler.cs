﻿using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var analisys = _mapper.Map<Entity.Analysis>(request);
                var parameter = analisys.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Analysis.ExecAsync(SP.uspAnalysisEdit, parameter);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message += ex.Message;
            }
            return response;
        }
    }
}
