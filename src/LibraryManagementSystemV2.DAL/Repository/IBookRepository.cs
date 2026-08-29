namespace LibraryManagementSystemV2.DAL.Repository;

public interface IBookRepository
{
    public Task<Book> CreateBookAsync(Book book, CancellationToken cancellationToken);
    public Task<bool> UpdateBookAsync(Book book, CancellationToken cancellationToken);
    public Task<bool> DeleteBookAsync(int bookId, CancellationToken cancellationToken);
    public Task<Book> GetBookByIdAsync(int bookId, CancellationToken cancellationToken);
    public Task<IEnumerable<SearchBookRecord>> SearchBookRecordAsync(string SearchBy, string SearchResult, CancellationToken cancellationToken);
}

public class BookRepository : IBookRepository
{
    private readonly IDbConnection _dbConnection;

    public BookRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
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

    public async Task<IEnumerable<SearchBookRecord>> SearchBookRecordAsync(string SearchBy, string SearchResult, CancellationToken cancellationToken)
    {
        var command = "dbo.SearchBookRecord";
        var parameters = new DynamicParameters();
        parameters.Add("@SearchBy", SearchBy);
        parameters.Add("@SearchResult", SearchResult);

        return await _dbConnection.QueryAsync<SearchBookRecord>(command, parameters, commandType: CommandType.StoredProcedure);
    }
}