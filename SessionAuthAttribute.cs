using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using HdiBackend.Data;

namespace HdiBackend
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SessionAuthAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            Console.WriteLine("--- NUEVA PETICIÓN RECIBIDA ---");
            foreach (var header in context.HttpContext.Request.Headers)
            {
                Console.WriteLine($"Header: {header.Key} = {header.Value}");
            }

            if (!context.HttpContext.Request.Headers.TryGetValue("X-User-Session", out var userIdStr))
            {
                Console.WriteLine("ERROR: Falta el header X-User-Session");
                context.Result = new UnauthorizedObjectResult(new { mensaje = "Falta el header X-User-Session" });
                return;
            }

            if (!int.TryParse(userIdStr, out int userId))
            {
                Console.WriteLine($"ERROR: El ID '{userIdStr}' no es un número válido");
                context.Result = new UnauthorizedObjectResult(new { mensaje = "ID de sesión inválido" });
                return;
            }

            var dbContext = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
            bool existe = dbContext.Users.Any(u => u.IdUser == userId);
            
            Console.WriteLine($"DEBUG: Buscando usuario ID {userId} en BD. ¿Existe?: {existe}");

            if (!existe)
            {
                context.Result = new UnauthorizedObjectResult(new { mensaje = "Usuario no existe en BD" });
                return;
            }

            await next();
        }
    }
}