using Microsoft.AspNetCore.Mvc;
using HdiBackend.Services;
using HdiBackend.DTOs;

namespace HdiBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Autenticar([FromBody] LoginRequest request)
        {
            var usuario = await _authService.Authenticate(request.Username, request.Password);

            if (usuario == null)
            {
                return Unauthorized("Credenciales incorrectas.");
            }

            return Ok(new
            {
                idUser = usuario.IdUser,
                name = usuario.Name,
                idType = usuario.IdType,
                username = usuario.Username
            });
        }

        [HttpPost("registrar-ajustador")]
        public async Task<IActionResult> CreateAdjuster([FromBody] RegisterAdjusterRequest request)
        {
            var success = await _authService.RegisterAdjuster(request);

            if (!success)
            {
                return BadRequest(new { message = "El nombre de usuario ya está registrado." });
            }

            return Ok(new { message = "Ajustador creado con éxito." });
        }

    }
}