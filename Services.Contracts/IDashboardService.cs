using Shared.DataTransferObjects;

namespace Services.Contracts
{
    public interface IDashboardService
    {
        DashboardDto GetDashboard();
    }
}
