namespace LibraryManagementSystemV2.BLL.Services;

public interface IDashboardInformationService
{
    public Task<DashBoardDto> GetDashboardInformationAsync(int recordLimit, CancellationToken cancellationToken);
}

public class DashboardInformationService(IDashboardInformationRepository dashboardInformationRepository)
    : IDashboardInformationService
{
    public async Task<DashBoardDto> GetDashboardInformationAsync(int recordLimit, CancellationToken cancellationToken)
    {
        var result = await dashboardInformationRepository.GetDashboardInformationAsync(recordLimit, cancellationToken);
        return result.Adapt<DashBoardDto>();
    }
}