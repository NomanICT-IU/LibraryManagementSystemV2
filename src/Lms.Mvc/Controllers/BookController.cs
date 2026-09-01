using Lms.Mvc.Models;
using Lms.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> Index(string searchText = "", int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var result = await bookService.GetBooksync(searchText, pageNumber, pageSize, cancellationToken);

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            BookModel bookModel,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(bookModel);
            }

            var result = await bookService.CreateBookAsync(
                bookModel,
                cancellationToken);

            if (result?.Data is not null)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(
                string.Empty,
                "Unable to create the book.");

            return View(bookModel);
        }


        [HttpGet]
        public IActionResult Update(int bookId)
        {
            return View();
        }


        [HttpPut]
        public IActionResult Update([FromBody] BookModel book)
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int bookId)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detail(int bookId)
        {
            return View();
        }


        public async Task<IActionResult> SearchBooks(string searchBy = "", string searchText = "", CancellationToken cancellationToken = default)
        {
            var result = await bookService.SearchBookRecordAsync(searchBy, searchText, cancellationToken);

            ViewBag.SearchBy = searchBy;
            ViewBag.SearchText = searchText;

            return View(result);
        }
    }
}
