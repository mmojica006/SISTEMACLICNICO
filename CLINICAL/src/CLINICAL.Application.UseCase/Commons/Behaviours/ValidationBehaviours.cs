using CLINICAL.Application.UseCase.Commons.Bases;
using FluentValidation;
using MediatR;
using ValidationException = CLINICAL.Application.UseCase.Commons.Exceptions.ValidationException;

namespace CLINICAL.Application.UseCase.Commons.Behaviours
{

    public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// Metodo que realiza la validacion def los REQUEST
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                //Filtrar los resultados, solo los que tienen errores

                var failures = validationResults.Where(x => x.Errors.Any()).ToList().SelectMany(x => x.Errors)
                    .Select(x => new BaseError()
                    {
                        ErrorMessage = x.ErrorMessage,
                        PropertyName = x.PropertyName,
                    }).ToList();

                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }


            }

            //si no hay errores de validacion, continuemos con el siguiente PIPELINE
            return await next();
        }
    }
}
