namespace LibraryManagementSystemV2.DAL.Repository;

public interface IBorrowRecordRepository
{
    public Task<BorrowRecordDetails> CreateBorrowRecordAsync(BorrowRecord record, CancellationToken cancellationToken);
    public Task<bool> UpdateBorrowRecordAsync(BorrowRecord record, CancellationToken cancellationToken);
    public Task<bool> DeleteBorrowRecordAsync(int borrowId, CancellationToken cancellationToken);
    public Task<BorrowRecord> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken);
}

public class BorrowRecordRepository : IBorrowRecordRepository
{
    private readonly IDbConnection _dbConnection;

    public BorrowRecordRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<BorrowRecordDetails> CreateBorrowRecordAsync(BorrowRecord record, CancellationToken cancellationToken)
    {
        var command = "dbo.CreateBorrowRecord";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", record.CopyId);
        parameters.Add("@MemberId", record.MemberId);
        parameters.Add("@IssueDate", record.IssueDate);
        parameters.Add("@DueDate", record.DueDate);
        parameters.Add("@ReturnDate", record.ReturnDate);


        return await _dbConnection.QuerySingleAsync<BorrowRecordDetails>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> DeleteBorrowRecordAsync(int borrowId, CancellationToken cancellationToken)
    {
        var command = "dbo.DeleteBorrowRecord";
        var parameters = new DynamicParameters();
        parameters.Add("@BorrowId", borrowId);
        int effectedRows = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }

    public async Task<BorrowRecord> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken)
    {
        var command = "dbo.GetBorrowRecordById";
        var parameters = new DynamicParameters();
        parameters.Add("@BorrowId", borrowId);
        return await _dbConnection.QuerySingleAsync<BorrowRecord>(command, parameters, commandType: CommandType.StoredProcedure);

    }

    public async Task<bool> UpdateBorrowRecordAsync(BorrowRecord record, CancellationToken cancellationToken)
    {
        var command = "dbo.UpdateBorrowRecord";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", record.CopyId);
        parameters.Add("@MemberId", record.MemberId);
        parameters.Add("@IssueDate", record.IssueDate);
        parameters.Add("@DueDate", record.DueDate);
        parameters.Add("@ReturnDate", record.ReturnDate);
        int effectedRows = await _dbConnection.ExecuteAsync(command, parameters, commandType: CommandType.StoredProcedure);
        return effectedRows > 0;
    }
}