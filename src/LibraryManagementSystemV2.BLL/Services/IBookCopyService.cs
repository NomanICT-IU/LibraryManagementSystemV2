namespace LibraryManagementSystemV2.BLL.Services;

public interface IBookCopyService
{
    public Task<BookCopyDto> CreateBookCopyAsync(BookCopyDto bookCopyDto, CancellationToken cancellationToken);
    public Task<bool> UpdateBookCopyAsync(BookCopyDto bookCopyDto, CancellationToken cancellationToken);
    public Task<bool> DeleteBookCopyAsync(int copyId, CancellationToken cancellationToken);
    public Task<BookCopyDto> GetBookCopyByIdAsync(int copyId, CancellationToken cancellationToken);

}
public class BookCopyService : IBookCopyService
{
    private readonly IBookCopyRepository _bookCopyRepository;

    public BookCopyService(IBookCopyRepository bookCopyRepository)
    {
        _bookCopyRepository = bookCopyRepository;
    }
    public async Task<BookCopyDto> CreateBookCopyAsync(BookCopyDto bookCopyDto, CancellationToken cancellationToken)
    {
        var bookCopy = bookCopyDto.Adapt<BookCopy>();

        var result = await _bookCopyRepository.CreateBookCopyAsync(bookCopy, cancellationToken);
        return bookCopy.Adapt<BookCopyDto>();
    }

    public async Task<bool> DeleteBookCopyAsync(int copyId, CancellationToken cancellationToken)
    {
        return await _bookCopyRepository.DeleteBookCopyAsync(copyId, cancellationToken);

    }

    public async Task<BookCopyDto> GetBookCopyByIdAsync(int copyId, CancellationToken cancellationToken)
    {
        var bookCopy = await _bookCopyRepository.GetBookCopyByIdAsync(copyId, cancellationToken);
        return bookCopy.Adapt<BookCopyDto>();
    }

    public async Task<bool> UpdateBookCopyAsync(BookCopyDto bookCopyDto, CancellationToken cancellationToken)
    {
        var bookCopy = bookCopyDto.Adapt<BookCopy>();
        return await _bookCopyRepository.UpdateBookCopyAsync(bookCopy, cancellationToken);
    }
}