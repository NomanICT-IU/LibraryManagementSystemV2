using Lms.Mvc.Models;
using Lms.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers;

public class BookCopyController : Controller
{
    private readonly IBookCopyService _bookCopyService;
    private readonly IBookService _bookService;

    public BookCopyController(IBookCopyService bookCopyService, IBookService bookService)
    {
        _bookCopyService = bookCopyService;
        _bookService = bookService;
    }
    [HttpGet]
    public async Task<IActionResult> Index(string searchText = "", int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var response = await _bookCopyService.GetBookCopyListAsync(searchText, pageNumber, pageSize, cancellationToken);
        return View(response);
    }
    [HttpGet]
    public async Task<IActionResult> Create(
     CancellationToken cancellationToken)
    {

        var response = await _bookService.GetBooksync(
            "",
            1,
          1000,
            cancellationToken);

        if (response.IsError)
        {
            return View();
        }

        ViewBag.Books = response.Data.BookList;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookCopyModel bookCopyModel, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return View(bookCopyModel);
        }

        var response = await _bookCopyService.CreateBookCopiesAsync(
            bookCopyModel,
            cancellationToken);

        if (response.IsError)
        {
            ModelState.AddModelError(
                string.Empty,
                response.Message);

            return View(bookCopyModel);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Detail(
    int copyId,
    CancellationToken cancellationToken)
    {
        var response = await _bookCopyService.GetBookCopyById(
            copyId,
            cancellationToken);

        return View(response.Data);
    }

    [HttpGet]
    public async Task<IActionResult> Update(
    int copyId,
    CancellationToken cancellationToken)
    {
        var response = await _bookCopyService.GetBookCopyById(
            copyId,
            cancellationToken);

        return View(response.Data);
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Update(
    //    BookCopyModel bookCopyModel,
    //    CancellationToken cancellationToken)
    //{
    //    var response = await _bookCopyService.UpdateBookCopyAsync(bookCopyModel, cancellationToken);
    //    if (response.IsError)
    //    {
    //        return View("Error", new ErrorViewModel()
    //        {
    //            RequestId = response.Message
    //        });
    //    }
    //    else if (response.Data)
    //    {
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(bookCopyModel);
    //}
}
