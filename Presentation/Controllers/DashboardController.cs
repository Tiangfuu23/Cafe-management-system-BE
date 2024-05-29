using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Shared.DataTransferObjects;

namespace Presentation.Controllers 
{
    [ApiController]
    [Route("Dashboard")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IServiceManager _service;
        public DashboardController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult getDashboardInfo()
        {
            DashboardDto dashboardDto = _service.DashboardService.GetDashboard();
            return Ok(new {dashboardInfo = dashboardDto});

        }
    }
}
