namespace LibraryManagementSystemV2.BLL.Services;

public interface IDashboardInformationService
{
    public Task<DashBoardDto> GetDashboardInformationAsync(CancellationToken cancellationToken);
}

public class DashboardInformationService(IDashboardInformationRepository dashboardInformationRepository)
    : IDashboardInformationService
{
    public async Task<DashBoardDto> GetDashboardInformationAsync(CancellationToken cancellationToken)
    {
        var result = await dashboardInformationRepository.GetDashboardInformationAsync(cancellationToken);
        return result.Adapt<DashBoardDto>();
    }
}