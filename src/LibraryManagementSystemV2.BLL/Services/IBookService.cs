namespace LibraryManagementSystemV2.BLL.Services;

public interface IBookService
{
    public Task<BookDto> CreateBookAsync(BookDto bookDto, CancellationToken cancellationToken);
    public Task<bool> UpdateBookAsync(BookDto bookDto, CancellationToken cancellationToken);
    public Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken);
    public Task<BookDto> GetBookByIdAsync(int bookId, CancellationToken cancellationToken);
    public Task<IEnumerable<SearchBookRecordDto>> SearchBookRecordAsync(string SearchBy, string SearchResult, CancellationToken cancellationToken);

}

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
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


    public async Task<IEnumerable<SearchBookRecordDto>> SearchBookRecordAsync(string SearchBy, string SearchResult, CancellationToken cancellationToken)
    {
        var bookRecord = await _bookRepository.SearchBookRecordAsync(SearchBy, SearchResult, cancellationToken);
        return bookRecord.Adapt<IEnumerable<SearchBookRecordDto>>();
    }

}