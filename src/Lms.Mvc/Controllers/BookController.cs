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

        public async Task<IActionResult> Index(string searchBy = "", string searchText = "", CancellationToken cancellationToken = default)
        {
            var result = await bookService.SearchBookRecordAsync(searchBy, searchText, cancellationToken);

            ViewBag.SearchBy = searchBy;
            ViewBag.SearchText = searchText;

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create([FromBody] BookModel book)
        {
            return View();
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
    }
}
