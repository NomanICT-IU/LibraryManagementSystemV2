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
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var response = await dashboardService
                .GetDashBoardInformation(pageNumber, pageSize, cancellationToken);

            return View(response);
        }
    }
}
