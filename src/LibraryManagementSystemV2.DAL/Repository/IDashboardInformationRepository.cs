namespace LibraryManagementSystemV2.DAL.Repository;

public interface IDashboardInformationRepository
{
    public Task<DashBoard> GetDashboardInformationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
}
public class DashboardInformationRepository : IDashboardInformationRepository
{
    private readonly IDbConnection _dbConnection;

    public DashboardInformationRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<DashBoard> GetDashboardInformationAsync(int pageNumber, int pageSize,
        CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@PageNumber", pageNumber);
        parameters.Add("@PageSize", pageSize);

        var command = new CommandDefinition("dbo.GetDashboardInformation",
            parameters,
            commandType: CommandType.StoredProcedure);
        using var result = await _dbConnection.QueryMultipleAsync(command);

        var totalBooks = await result.ReadSingleAsync<int>();
        var availableCopies = await result.ReadSingleAsync<int>();
        var borrowedCopies = await result.ReadSingleAsync<int>();
        var members = await result.ReadSingleAsync<int>();
        var totalRecords = await result.ReadSingleAsync<int>();

        var recentBorrowedBooks = (await result.ReadAsync<RecentBorrowedBook>()).ToList();

        return new DashBoard
        {
            TotalBoks = totalBooks,
            AvailableCopies = availableCopies,
            BorrowedCopies = borrowedCopies,
            Members = members,
            TotalRecords = totalRecords,
            RecentBorrowedBooks = recentBorrowedBooks
        };
    }

}
