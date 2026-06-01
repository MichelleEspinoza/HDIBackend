using Microsoft.AspNetCore.Mvc;
using HdiBackend.DTOs;
using HdiBackend.Services;

namespace HdiBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SessionAuth]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService) => _reportService = reportService;

        [HttpPost]
        public async Task<IActionResult> CreateReport([FromBody] CreateReportRequest request)
        {
            var report = await _reportService.Create(request);
            return CreatedAtAction(nameof(GetReportById), new { id = report.IdReport }, report);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReportById(int id)
        {
            var report = await _reportService.GetById(id);
            return report != null ? Ok(report) : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult> GetReports([FromQuery] int idOffice, [FromQuery] string policyNumber)
        {
            var reports = await _reportService.GetByFilters(idOffice, policyNumber);
            return Ok(reports);
        }
    }
}