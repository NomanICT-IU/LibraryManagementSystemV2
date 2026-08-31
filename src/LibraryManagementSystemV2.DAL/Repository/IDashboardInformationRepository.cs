namespace LibraryManagementSystemV2.DAL.Repository;

public interface IDashboardInformationRepository
{
    public Task<DashBoard> GetDashboardInformationAsync(CancellationToken cancellationToken);
}
public class DashboardInformationRepository : IDashboardInformationRepository
{
    private readonly IDbConnection _dbConnection;

    public DashboardInformationRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
    public async Task<DashBoard> GetDashboardInformationAsync(
        CancellationToken cancellationToken)
    {
        var command = new CommandDefinition("dbo.GetDashboardInformation",
            commandType: CommandType.StoredProcedure);
        using var result = await _dbConnection.QueryMultipleAsync(command);

        var totalBooks = await result.ReadSingleAsync<int>();
        var availableCopies = await result.ReadSingleAsync<int>();
        var borrowedCopies = await result.ReadSingleAsync<int>();
        var member = await result.ReadSingleAsync<int>();

        var recentBorrowedBooks = (await result.ReadAsync<RecentBoardBook>()).ToList();

        return new DashBoard
        {
            TotalBoks = totalBooks,
            AvailableCopies = availableCopies,
            BorrowedCopies = borrowedCopies,
            Member = member,
            RecentBoardBooks = recentBorrowedBooks
        };
    }

}
