namespace Memorabilia.Application.Features.Dashboard;

public record GetSpotData() : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetSpotData, DashboardChartModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository, 
                       IApplicationStateService applicationStateService)
        {
            _repository = repository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<DashboardChartModel> Handle(GetSpotData query)
        {
            int[] spotIds = _repository.GetSpotIds(_applicationStateService.CurrentUser.Id);
            string[] spotNames = spotIds.Select(spotId => Constant.Spot.Find(spotId).Name)
                                        .Distinct()
                                        .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string spotName in spotNames)
            {
                var spot = Constant.Spot.Find(spotName);
                int count = spotIds.Count(spotId => spotId == spot.Id);

                counts.Add(count);
                labels.Add($"{spotName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
