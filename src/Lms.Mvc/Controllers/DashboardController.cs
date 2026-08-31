using Lms.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var response = await dashboardService
                .GetDashBoardInformation(cancellationToken);

            return View(response);
        }
    }
}
