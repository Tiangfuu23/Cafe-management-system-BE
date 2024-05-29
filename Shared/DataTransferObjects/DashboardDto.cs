

namespace Shared.DataTransferObjects
{
    public record DashboardDto()
    {
        public int categoryCnt { get; init; }
        public int productCnt { get; init; }
        public float revenue { get; init; }
        public int userCnt { get; init; }
    };
}
