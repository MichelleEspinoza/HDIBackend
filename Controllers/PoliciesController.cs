using Microsoft.AspNetCore.Mvc;
using HdiBackend.DTOs;
using HdiBackend.Services;

namespace HdiBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SessionAuth]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PoliciesController(IPolicyService policyService) => _policyService = policyService;

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] int? idOffice, [FromQuery] string? policyNumber)
        {
            var results = await _policyService.SearchPolicies(idOffice, policyNumber);
            if (!results.Any()) return NotFound("No se encontraron pólizas.");
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePolicyRequest request)
        {
            var success = await _policyService.CreatePolicy(request);
            if (!success) return StatusCode(500, "Error al guardar la póliza.");
            return Ok(new { message = "Póliza creada con éxito." });
        }


    }
}