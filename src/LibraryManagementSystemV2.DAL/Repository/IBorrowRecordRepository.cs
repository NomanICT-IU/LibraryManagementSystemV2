namespace LibraryManagementSystemV2.DAL.Repository;

public interface IBorrowRecordRepository
{
    public Task<BorrowRecord> CreateBorrowRecordAsync(BorrowRecord record, CancellationToken cancellationToken);
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
    public async Task<BorrowRecord> CreateBorrowRecordAsync(BorrowRecord record, CancellationToken cancellationToken)
    {
        var command = "dbo.CreateMember";
        var parameters = new DynamicParameters();
        parameters.Add("@CopyId", record.CopyId);
        parameters.Add("@MemberId", record.MemberId);
        parameters.Add("@IssueDate", record.IssueDate);
        parameters.Add("@DueDate", record.DueDate);
        parameters.Add("@ReturnDate", record.ReturnDate);


        return await _dbConnection.QuerySingleAsync<BorrowRecord>(command, parameters, commandType: CommandType.StoredProcedure);
    }

    public Task<bool> DeleteBorrowRecordAsync(int borrowId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<BorrowRecord> GetBorrowRecordByIdAsync(int borrowId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateBorrowRecordAsync(BorrowRecord record, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}