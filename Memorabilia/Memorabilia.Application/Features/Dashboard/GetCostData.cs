namespace Memorabilia.Application.Features.Dashboard;

public record GetCostData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetCostData, DashboardChartModel>
    {
        private readonly IAutographRepository _autographRepository;
        private readonly IMemorabiliaItemRepository _memorabiliaItemRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaItemRepository, IAutographRepository autographRepository)
        {
            _autographRepository = autographRepository;
            _memorabiliaItemRepository = memorabiliaItemRepository;
        }

        protected override async Task<DashboardChartModel> Handle(GetCostData query)
        {
            var autographsCostTotal = _autographRepository.GetCostTotal(query.UserId);
            var memorabiliaCostTotal = _memorabiliaItemRepository.GetCostTotal(query.UserId);
            
            var labels = new List<string>() { $"Memorabilia ({memorabiliaCostTotal:C})", $"Autographs ({autographsCostTotal:C})" }.ToArray();
            var data = new List<double>() { (double)memorabiliaCostTotal, (double)autographsCostTotal }.ToArray();

            return await Task.FromResult(new DashboardChartModel(data, labels));
        }
    }
}
