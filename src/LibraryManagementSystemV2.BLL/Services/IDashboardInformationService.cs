namespace LibraryManagementSystemV2.BLL.Services;

public interface IDashboardInformationService
{
    public Task<DashBoardDto> GetDashboardInformationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
}

public class DashboardInformationService(IDashboardInformationRepository dashboardInformationRepository)
    : IDashboardInformationService
{
    public async Task<DashBoardDto> GetDashboardInformationAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var result = await dashboardInformationRepository.GetDashboardInformationAsync(pageNumber, pageSize, cancellationToken);
        return new DashBoardDto
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalBoks = result.TotalBoks,
            AvailableCopies = result.AvailableCopies,
            BorrowedCopies = result.BorrowedCopies,
            Members = result.Members,
            TotalRecords = result.TotalRecords,
            RecentBorrowedBooks = result.RecentBorrowedBooks.Adapt<List<RecentBorrowedBookDto>>()
        };

    }
}