namespace Memorabilia.Application.Features.Dashboard;

public record GetEstimatedValueData() 
    : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetEstimatedValueData, DashboardChartModel>
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

        protected override async Task<DashboardChartModel> Handle(GetEstimatedValueData query)
        {
            decimal autographsEstimatedValueTotal 
                = _autographRepository.GetEstimatedValueTotal(_applicationStateService.CurrentUser.Id);

            decimal memorabiliaEstimatedValueTotal 
                = _memorabiliaItemRepository.GetEstimatedValueTotal(_applicationStateService.CurrentUser.Id);

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
