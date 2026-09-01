namespace LibraryManagementSystemV2.DAL.Repository;

public interface IBookRepository
{
    public Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken);
    public Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken);
    public Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken);
    public Task<Book> GetBookByIdAsync(int bookId, CancellationToken cancellationToken);
    public Task<IEnumerable<BookCopyDetails>> SearchBookRecordAsync(string searchBy, string searchText, CancellationToken cancellationToken);
    public Task<BookDetailsResponse> GetBookDetailsAsync(string searchBy, string searchText, CancellationToken cancellationToken);
    public Task<BookDetails> GetBookCopyDetailsAsync(int bookId, CancellationToken cancellationToken);
    public Task<BookListResponse> GetBookListAsync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken);
}

public class BookRepository : IBookRepository
{
    private readonly IDbConnection _dbConnection;

    public BookRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<BookListResponse> GetBookListAsync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@SearchText", searchText);
        parameters.Add("@PageNumber", pageNumber);
        parameters.Add("@PageSize", pageSize);

        var command = new CommandDefinition(
           "dbo.GetBookList",
           parameters,
           commandType: CommandType.StoredProcedure,
           cancellationToken: cancellationToken);

        using var multi = await _dbConnection.QueryMultipleAsync(command);

        var bookList = (await multi.ReadAsync<Book>()).ToList();

        var totalRecords = await multi.ReadSingleOrDefaultAsync<int>();

        return new BookListResponse
        {
            TotalRecords = totalRecords,
            BookList = bookList
        };
    }
    public async Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken)
    {
        var command = "dbo.CreateBook";
        var parameters = new DynamicParameters();
        parameters.Add("@Title", book.Title);
        parameters.Add("@Author", book.Author);
        parameters.Add("@ISBN", book.ISBN);
        parameters.Add("@Category", book.Category);

        return await _dbConnection.QuerySingleAsync<Book>(command, parameters, commandType: CommandType.StoredProcedure);
    }
    public async Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken)
    {
        var command = "dbo.DeleteBook";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", bookId);
        int effectedRows = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }

    public async Task<Book> GetBookByIdAsync(int bookId, CancellationToken cancellationToken)
    {
        var command = "dbo.GetBookById";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", bookId);

        return await _dbConnection.QuerySingleAsync<Book>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken)
    {
        var command = "dbo.UpdateBook";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", book.BookId);
        parameters.Add("@Title", book.Title);
        parameters.Add("@Author", book.Author);
        parameters.Add("@ISBN", book.ISBN);
        parameters.Add("@Category", book.Category);
        int effectedRows = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }

    public async Task<BookDetailsResponse> GetBookDetailsAsync(
         string searchBy,
         string searchText,
         CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@SearchBy", searchBy);
        parameters.Add("@SearchText", searchText);

        var command = new CommandDefinition(
            "dbo.GetBookDetails",
            parameters,
            commandType: CommandType.StoredProcedure,
            cancellationToken: cancellationToken);

        using var multi = await _dbConnection.QueryMultipleAsync(command);

        var bookInformation =
            (await multi.ReadAsync<BookInformation>()).ToList();

        var bookAvailabilitySummary =
            (await multi.ReadAsync<BookAvailabilitySummary>()).ToList();
        var copyInformation =
            (await multi.ReadAsync<CopyInformation>()).ToList();

        return new BookDetailsResponse
        {
            BookInformation = bookInformation,
            BookAvailabilitySummary = bookAvailabilitySummary,
            CopyInformation = copyInformation,
        };

    }


    public async Task<BookDetails> GetBookCopyDetailsAsync(int bookId, CancellationToken cancellationToken)
    {
        var command = "dbo.GetBookCopyDetails";
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", bookId);

        return await _dbConnection.QuerySingleAsync<BookDetails>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<BookCopyDetails>> SearchBookRecordAsync(string searchBy, string searchText, CancellationToken cancellationToken)
    {
        var command = "dbo.SearchBookRecord";
        var parameters = new DynamicParameters();
        parameters.Add("@SearchBy", searchBy);
        parameters.Add("@SearchText", searchText);

        return await _dbConnection.QueryAsync<BookCopyDetails>(command, parameters, commandType: CommandType.StoredProcedure);
    }
}