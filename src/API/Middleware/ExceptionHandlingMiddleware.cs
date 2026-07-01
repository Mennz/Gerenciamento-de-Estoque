using System.Net;
using System.Text.Json;
using GerenciamentoEstoqueAPI.Core.Exceptions;

namespace GerenciamentoEstoqueAPI.API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro não tratado na aplicação.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // Status padrão 500
            var mensagem = "Ocorreu um erro interno no servidor. Tente novamente mais tarde.";

            // Mapeia nossas exceções customizadas para os status HTTP corretos
            if (exception is BusinessException)
            {
                code = HttpStatusCode.BadRequest; // 400
                mensagem = exception.Message;
            }
            else if (exception is NotFoundException)
            {
                code = HttpStatusCode.NotFound; // 404
                mensagem = exception.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var resultado = JsonSerializer.Serialize(new 
            { 
                status = context.Response.StatusCode,
                erro = mensagem,
                data_ocorrencia = DateTime.UtcNow
            });

            return context.Response.WriteAsync(resultado);
        }
    }
}