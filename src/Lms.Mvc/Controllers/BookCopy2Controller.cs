using Lms.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers;

public class BookCopy2Controller : Controller
{
    private readonly IBookCopyService _bookCopyService;

    public BookCopy2Controller(IBookCopyService bookCopyService)
    {
        _bookCopyService = bookCopyService;
    }
    public IActionResult Index()
    {
        return View();
    }
}
