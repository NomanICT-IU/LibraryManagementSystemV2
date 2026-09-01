namespace LibraryManagementSystemV2.BLL.Services;

public interface IBookService
{
    public Task<BookDto> CreateBookAsync(BookDto bookDto, CancellationToken cancellationToken);
    public Task<bool> UpdateBookAsync(BookDto bookDto, CancellationToken cancellationToken);
    public Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken);
    public Task<BookDto> GetBookByIdAsync(int bookId, CancellationToken cancellationToken);
    public Task<IEnumerable<BookCopyDetailsDto>> SearchBookRecordAsync(string searchBy, string searchText, CancellationToken cancellationToken);
    public Task<BookDetailsResponseDto> GetBookDetailsAsync(string searchBy, string searchText, CancellationToken cancellationToken);
    public Task<BookDetailsDto> GetBookCopyDetailsAsync(int bookId, CancellationToken cancellationToken);
    public Task<BookListResponseDto> GetBookListAsync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken);

}

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<BookListResponseDto> GetBookListAsync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var result = await _bookRepository.GetBookListAsync(searchText, pageNumber, pageSize, cancellationToken);

        return new BookListResponseDto
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = result.TotalRecords,
            BookList = result.BookList.Adapt<List<BookDto>>()
        };
    }
    public async Task<BookDto> CreateBookAsync(BookDto bookDto, CancellationToken cancellationToken)
    {
        var book = bookDto.Adapt<Book>();
        var result = await _bookRepository.CreateBookAsync(book, cancellationToken);
        return result.Adapt<BookDto>();
    }

    public async Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken)
    {
        return await _bookRepository.DeleteBookAsync(bookId, cancellationToken);
    }

    public async Task<BookDto> GetBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBookByIdAsync(bookId, cancellationToken);
        return book.Adapt<BookDto>();
    }

    public async Task<bool> UpdateBookAsync(BookDto bookDto, CancellationToken cancellationToken)
    {
        var book = bookDto.Adapt<Book>();
        return await _bookRepository.UpdateBookAsync(book, cancellationToken);
    }


    public async Task<BookDetailsResponseDto> GetBookDetailsAsync(
    string searchBy,
    string searchResult,
    CancellationToken cancellationToken)
    {
        var bookDetails = await _bookRepository.GetBookDetailsAsync(
            searchBy,
            searchResult,
            cancellationToken);

        return new BookDetailsResponseDto
        {
            BookInformationDto = bookDetails.BookInformation.Adapt<List<BookInformationDto>>(),

            BookAvailabilitySummaryDto = bookDetails.BookAvailabilitySummary.Adapt<List<BookAvailabilitySummaryDto>>(),

            CopyInformationDto = bookDetails.CopyInformation.Adapt<List<CopyInformationDto>>()
        };
    }

    public async Task<BookDetailsDto> GetBookCopyDetailsAsync(int bookId, CancellationToken cancellationToken)
    {
        var bookDetails = await _bookRepository.GetBookCopyDetailsAsync(bookId, cancellationToken);
        return bookDetails.Adapt<BookDetailsDto>();
    }

    public async Task<IEnumerable<BookCopyDetailsDto>> SearchBookRecordAsync(string searchBy, string searchText, CancellationToken cancellationToken)
    {
        var bookRecords = await _bookRepository.SearchBookRecordAsync(searchBy, searchText, cancellationToken);
        return bookRecords.Adapt<IEnumerable<BookCopyDetailsDto>>();
    }


}