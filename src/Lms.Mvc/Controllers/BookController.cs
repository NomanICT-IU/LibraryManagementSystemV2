
using Lms.Mvc.Models;
using Lms.Mvc.Models.ViewModels;
using Lms.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IMemberService memberService;
        private readonly IBorrowRecordService borrowRecordService;

        public BookController(IBookService bookService, IMemberService memberService,
            IBorrowRecordService borrowRecordService)
        {
            this.bookService = bookService;
            this.memberService = memberService;
            this.borrowRecordService = borrowRecordService;
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
        public async Task<IActionResult> Create(BookModel bookModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(bookModel);
            }

            var result = await bookService.CreateBookAsync(
                bookModel,
                cancellationToken);

            if (result is not null)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(
                string.Empty,
                "Unable to create the book.");

            return View(bookModel);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int bookId, CancellationToken cancellationToken)
        {
            var result = await bookService.GetBookByIdAsync(bookId, cancellationToken);
            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int bookId, CancellationToken cancellationToken)
        {
            var result = await bookService.GetBookByIdAsync(bookId, cancellationToken);
            return View(result.Data);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BookModel book, CancellationToken cancellationToken)
        {
            var response = await bookService.UpdateBookAsync(book, cancellationToken);
            if (response.IsError)
            {
                return View("Error", new ErrorViewModel()
                {
                    RequestId = response.Message
                });
            }
            else if (response.Data)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int bookId, CancellationToken cancellationToken)
        {
            var response = await bookService.DeleteBookAsync(bookId, cancellationToken);
            if (response.IsError)
            {
                return View("Error", new ErrorViewModel()
                {
                    RequestId = response.Message
                });
            }
            else if (response.Data)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Detail), new { bookId });
            }
        }


        public async Task<IActionResult> SearchBooks(string searchBy = "", string searchText = "", int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            var result = await bookService.SearchBookRecordAsync(searchBy, searchText, pageNumber, pageSize, cancellationToken);

            ViewBag.SearchBy = searchBy;
            ViewBag.SearchText = searchText;
            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            return View(result.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Issue(BookIssueModel BIM, CancellationToken cancellationToken = default)
        {
            var book = await bookService.GetBookCopyDetailsAsync(BIM.CopyId,
                cancellationToken);

            var bvm = new BookIssueViewModel
            {
                Book = book.Data,
                BookIssue = BIM

            };

            if (!string.IsNullOrWhiteSpace(BIM.MemberSearch))
            {
                var member = await memberService.FindMemberAsync(
                    BIM.MemberSearch,
                    cancellationToken);
                if (member != null)
                {
                    bvm.Member = member.Data;
                    bvm.Issue = new IssueInformationModel()
                    {
                        IssueDate = DateTime.Now,
                        CopyId = BIM.CopyId,
                        MemberId = bvm.Member.MemberId,
                        DueDate = DateTime.Now.AddDays(7)

                    };
                }
            }

            return View(bvm);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmIssue(BookIssueViewModel vm, CancellationToken cancellationToken)
        {
            var response = await borrowRecordService
                .CreateBorrowRecordAsync(vm.Issue, cancellationToken);

            if (response.Data)
            {
                if (vm.BookIssue.ReturnPage == "SearchBooks")
                {
                    return RedirectToAction(nameof(SearchBooks));
                }

                if (vm.BookIssue.ReturnPage == "BookDetails")
                {
                    return RedirectToAction(
                        nameof(BookDetails),
                        new
                        {
                            searchBy = vm.BookIssue.SearchBy,
                            searchResult = vm.BookIssue.SearchResult
                        });
                }
            }

            ModelState.AddModelError(
                string.Empty,
                response.Message ?? "Failed to issue the book.");

            return View("Issue", vm);
        }

        [HttpGet]
        public async Task<IActionResult> BookDetails(string searchBy = "", string searchResult = "", CancellationToken cancellationToken = default)
        {
            var model = new BookDetailsResponseViewModel
            {
                SearchBy = searchBy,
                SearchResult = searchResult
            };

            if (!string.IsNullOrWhiteSpace(searchBy) &&
                !string.IsNullOrWhiteSpace(searchResult))
            {
                var response = await bookService.GetBookDetailsAsync(
                    searchBy,
                    searchResult,
                    cancellationToken);

                if (response?.Data != null)
                {
                    model = response.Data;


                    model.SearchBy = searchBy;
                    model.SearchResult = searchResult;
                }
            }

            return View(model);
        }

    }

}

