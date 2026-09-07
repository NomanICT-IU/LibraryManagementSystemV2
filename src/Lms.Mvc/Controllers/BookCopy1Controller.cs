using Lms.Mvc.Models.ViewModels;
using Lms.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers;

public class BookCopy1Controller : Controller
{
    private readonly IBookCopyService _bookCopyService;

    public BookCopy1Controller(IBookCopyService bookCopyService)
    {
        _bookCopyService = bookCopyService;
    }
    [HttpGet]
    public async Task<IActionResult> Index(int bookId, int CopyId = 0, CancellationToken cancellationToken = default)
    {

        var bookList = await _bookCopyService.GetBookCopyListAsync(bookId, cancellationToken);
        var vm = new BookCopyViewModel();

        vm.BookCopies = bookList.Data;
        vm.BookCopy.BookId = bookId;
        vm.BookCopy.Status = 1;

        if (vm.BookCopy.CopyId > 0)
        {
            var bookCopy = await _bookCopyService.GetBookCopyById(vm.BookCopy.CopyId, cancellationToken);
            vm.BookCopy = bookCopy.Data;
        }

        return View(vm);
    }
    [HttpPost]
    public async Task<IActionResult> Save(BookCopyViewModel vm, CancellationToken cancellationToken)
    {
        var bookModel = vm.BookCopy;
        if (bookModel.CopyId == 0)
        {
            await _bookCopyService.CreateBookCopiesAsync(bookModel, cancellationToken);
        }
        else
        {
            await _bookCopyService.UpdateBookCopyAsync(bookModel.CopyId, bookModel, cancellationToken);
        }
        return RedirectToAction(nameof(Index), new { bookId = bookModel.BookId });
    }
}
