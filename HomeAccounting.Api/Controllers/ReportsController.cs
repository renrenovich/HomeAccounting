using HomeAccounting.Application.Commands;
using HomeAccounting.Application.Contracts;
using HomeAccounting.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeAccounting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        
        [HttpGet("monthly")]
        [SwaggerOperation(
            Summary = "Gets the monthly report",
            Description = "Retrieves the period report based on the categoriesId and usersId provided.",
            OperationId = "GetMonthlyReport",
            Tags = new[] { "Reports" }
        )]
        [SwaggerResponse(200, "Returns the monthly purchases.", typeof( IEnumerable<Purchase>))]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> GetMonthlyReport([FromQuery] GetMonthlyReport request)
        {
            try
            {
                var report = await _reportService.GetMonthlyReportAsync(request);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }

        
        [HttpGet("period")]
        [SwaggerOperation(
            Summary = "Gets the period report",
            Description = "Retrieves the period report based on the categoriesId and usersId provided.",
            OperationId = "GetPeriodReport",
            Tags = new[] { "Reports" }
        )]
        [SwaggerResponse(200, "Returns the period report.", typeof( Report))]
        [SwaggerResponse(500, "Internal server error.")]
        public async Task<IActionResult> GetPeriodReport([FromQuery] GetPeriodReport request)
        {
            try
            {
                var report = await _reportService.GetPeriodReportAsync(request);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex.Message}");
            }
        }
    }
}
