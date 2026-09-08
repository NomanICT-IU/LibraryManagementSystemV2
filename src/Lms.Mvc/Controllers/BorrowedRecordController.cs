using Lms.Mvc.Models;
using Lms.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers;

public class BorrowedRecordController : Controller
{
    private readonly IBorrowRecordService borrowRecordService;

    public BorrowedRecordController(IBorrowRecordService borrowRecordService)
    {
        this.borrowRecordService = borrowRecordService;
    }
    public async Task<IActionResult> Index(string searchBy = "", string searchText = "", CancellationToken cancellationToken = default)
    {
        var models = new List<BorrowBookSearchResultModel>();

        if (!string.IsNullOrWhiteSpace(searchBy) && !string.IsNullOrWhiteSpace(searchText))
        {
            var response = await borrowRecordService
           .SearchBorrowedBookAsync(searchBy, searchText, cancellationToken);

            models = response.Data.ToList();
            ViewBag.SearchBy = searchBy;
            ViewBag.SearchText = searchText;
        }

        return View(models);
    }
    [HttpPost]
    public async Task<IActionResult> ConfirmReturn(
     int borrowId,
     CancellationToken cancellationToken)
    {
        var response = await borrowRecordService
            .ReturnBorrowedBookAsync(borrowId, cancellationToken);

        if (response.Data)
        {
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }
}
