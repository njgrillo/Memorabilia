namespace Memorabilia.Application.Features.Dashboard;

public record GetCostData() : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetCostData, DashboardChartModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IAutographRepository _autographRepository;
        private readonly IMemorabiliaItemRepository _memorabiliaItemRepository;

        public Handler(IMemorabiliaItemRepository memorabiliaItemRepository, 
                       IAutographRepository autographRepository,
                       IApplicationStateService applicationStateService)
        {
            _autographRepository = autographRepository;
            _memorabiliaItemRepository = memorabiliaItemRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<DashboardChartModel> Handle(GetCostData query)
        {
            decimal autographsCostTotal = _autographRepository.GetCostTotal(_applicationStateService.CurrentUser.Id);
            decimal memorabiliaCostTotal = _memorabiliaItemRepository.GetCostTotal(_applicationStateService.CurrentUser.Id);
            
            var labels = new List<string>() 
            { 
                $"Memorabilia ({memorabiliaCostTotal:C})", 
                $"Autographs ({autographsCostTotal:C})" 
            }.ToArray();

            var data = new List<double>() 
            { 
                (double)memorabiliaCostTotal, 
                (double)autographsCostTotal 
            }.ToArray();

            return await Task.FromResult(new DashboardChartModel(data, labels));
        }
    }
}
