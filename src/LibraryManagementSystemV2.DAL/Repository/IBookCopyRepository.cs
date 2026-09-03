namespace LibraryManagementSystemV2.DAL.Repository;

public interface IBookCopyRepository
{
    public Task<BookCopy> CreateBookCopyAsync(BookCopy bookCopy, CancellationToken cancellationToken);
    public Task<bool> UpdateBookCopyAsync(BookCopy bookCopy, CancellationToken cancellationToken);
    public Task<bool> DeleteBookCopyAsync(int copyId, CancellationToken cancellationToken);
    public Task<BookCopyView> GetBookCopyByIdAsync(int copyId, CancellationToken cancellationToken);
    public Task<BookCopyResponse> GetBookCopyListAsync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken);
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

    public async Task<BookCopyResponse> GetBookCopyListAsync(string searchText, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@PageNumber", pageNumber);
        parameters.Add("@PageSize", pageSize);
        parameters.Add("@SearchText", searchText);

        using var multi = await _dbConnection.QueryMultipleAsync(
            new CommandDefinition(
                "dbo.GetBookCopyList",
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken));

        var bookCopies = (await multi.ReadAsync<BookCopies>()).ToList();

        var totalRecords = await multi.ReadSingleAsync<int>();

        return new BookCopyResponse
        {
            TotalRecords = totalRecords,
            BookCopies = bookCopies
        };

    }



    public async Task<bool> UpdateBookCopyAsync(BookCopy bookCopy, CancellationToken cancellationToken)
    {
        var command = "dbo.UpdateBookCopy";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", bookCopy.CopyId);
        parameters.Add("@CopyCode", bookCopy.CopyCode);
        parameters.Add("@BookId", bookCopy.BookId);
        parameters.Add("@Status", bookCopy.Status);

        var effectedRow = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRow > 0;
    }
}