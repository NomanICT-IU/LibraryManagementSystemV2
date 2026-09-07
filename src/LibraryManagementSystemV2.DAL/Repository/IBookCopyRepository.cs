namespace LibraryManagementSystemV2.DAL.Repository;



public interface IBookCopyRepository
{
    public Task<BookCopy> CreateBookCopyAsync(BookCopy bookCopy, CancellationToken cancellationToken);
    public Task<bool> UpdateBookCopyAsync(int copyId, BookCopy bookCopy, CancellationToken cancellationToken);
    public Task<bool> DeleteBookCopyAsync(int copyId, CancellationToken cancellationToken);
    public Task<BookCopyView> GetBookCopyByIdAsync(int copyId, CancellationToken cancellationToken);
    public Task<IEnumerable<BookCopyResponse>> GetBookCopyListAsync(int bookId, CancellationToken cancellationToken);
}



public class BookCopyRepository : IBookCopyRepository
{
    private readonly IDbConnection _dbConnection;

    public BookCopyRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<BookCopy> CreateBookCopyAsync(BookCopy bookCopy, CancellationToken cancellationToken)
    {
        var command = "dbo.CreateBookCopy";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyCode", bookCopy.CopyCode);
        parameters.Add("@BookId", bookCopy.BookId);
        parameters.Add("@Status", bookCopy.Status);

        return await _dbConnection.QuerySingleAsync<BookCopy>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> DeleteBookCopyAsync(int copyId, CancellationToken cancellationToken)
    {
        var command = "dbo.DeleteBookCopy";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", copyId);
        var effectedRow = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRow > 0;
    }

    public async Task<BookCopyView> GetBookCopyByIdAsync(int copyId, CancellationToken cancellationToken)
    {
        var command = "dbo.GetBookCopyById";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", copyId);
        return await _dbConnection.QuerySingleAsync<BookCopyView>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<BookCopyResponse>> GetBookCopyListAsync(
    int bookId,
    CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@BookId", bookId);

        const string command = "dbo.GetBookCopyList";

        return await _dbConnection.QueryAsync<BookCopyResponse>(
            command,
            parameters,
            commandType: CommandType.StoredProcedure);
    }


    public async Task<bool> UpdateBookCopyAsync(int copyId, BookCopy bookCopy, CancellationToken cancellationToken)
    {
        var command = "dbo.UpdateBookCopy";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", copyId);
        parameters.Add("@CopyCode", bookCopy.CopyCode);
        parameters.Add("@BookId", bookCopy.BookId);
        parameters.Add("@Status", bookCopy.Status);

        var effectedRow = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRow > 0;
    }
}