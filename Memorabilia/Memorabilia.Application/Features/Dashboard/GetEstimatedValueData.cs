namespace Memorabilia.Application.Features.Dashboard;

public record GetEstimatedValueData(int UserId) 
    : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetEstimatedValueData, DashboardChartModel>
    {
        private readonly IAutographRepository _autographRepository;
        private readonly IMemorabiliaItemRepository _memorabiliaItemRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaItemRepository, 
            IAutographRepository autographRepository)
        {
            _autographRepository = autographRepository;
            _memorabiliaItemRepository = memorabiliaItemRepository;
        }

        protected override async Task<DashboardChartModel> Handle(GetEstimatedValueData query)
        {
            decimal autographsEstimatedValueTotal = _autographRepository.GetEstimatedValueTotal(query.UserId);
            decimal memorabiliaEstimatedValueTotal = _memorabiliaItemRepository.GetEstimatedValueTotal(query.UserId);

            var labels = new List<string>() 
            { 
                $"Memorabilia ({memorabiliaEstimatedValueTotal:C})", 
                $"Autographs ({autographsEstimatedValueTotal:C})" 
            }.ToArray();

            var data = new List<double>() 
            { 
                (double)memorabiliaEstimatedValueTotal, 
                (double)autographsEstimatedValueTotal 
            }.ToArray();

            return await Task.FromResult(new DashboardChartModel(data, labels));
        }
    }
}
