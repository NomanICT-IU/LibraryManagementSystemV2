using Lms.Mvc.Models;
using Lms.Mvc.Models.ViewModels;
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
    public async Task<IActionResult> Index(
     int bookId, int copyId = 0,
     CancellationToken cancellationToken = default)
    {

        var book = await _bookService.GetBookByIdAsync(
            bookId,
            cancellationToken);
        var bookList = await _bookCopyService.GetBookCopyListAsync(bookId,
            cancellationToken);

        BookCopyViewModel vm = new BookCopyViewModel();
        //vm.BookTitle = book.Data.Title;
        vm.BookCopies = bookList.Data;
        vm.BookCopy.BookId = bookId;
        vm.BookCopy.Status = 1;

        if (copyId > 0)
        {
            var result = await _bookCopyService.GetBookCopyById(copyId, cancellationToken);
            vm.BookCopy = result.Data;
        }

        return View(vm);
    }


    [HttpPost]
    public async Task<IActionResult> Save(BookCopyModel vm, CancellationToken cancellationToken)
    {
        if (vm.CopyId == 0)
        {
            await _bookCopyService.CreateBookCopiesAsync(vm, cancellationToken);
        }
        else
        {
            await _bookCopyService.UpdateBookCopyAsync(vm.CopyId, vm, cancellationToken);
        }

        return RedirectToAction(nameof(Index), new { bookid = vm.BookId });

    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(
    int copyId,
    int bookId,
    CancellationToken cancellationToken)
    {
        var response = await _bookCopyService.DeleteBookCopyAsync(
            copyId,
            cancellationToken);

        if (response.IsError)
        {
            return View("Error", new ErrorViewModel
            {
                RequestId = response.Message
            });
        }

        return RedirectToAction(
            nameof(Index),
            new { bookId });
    }


}
