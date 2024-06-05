using CLINICAL.Application.UseCase.Commons.Bases;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using ValidationException = CLINICAL.Application.UseCase.Commons.Exceptions.ValidationException;

namespace CLINICAL.Api.Extensions.Middleware
{
    /// <summary>
    /// Se implementa el manejo de validaciones
    /// </summary>
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;
        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Metodo para procesar esta solicitud
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {

                await _next.Invoke(context);

            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = "Errores de validación",
                    Errors = ex.Errors

                });
            }
        }

    }
}
