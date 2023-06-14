namespace Memorabilia.Application.Features.Dashboard;

public record GetFranchiseData() : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetFranchiseData, DashboardChartModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository, 
                       IApplicationStateService applicationStateService)
        {
            _repository = repository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<DashboardChartModel> Handle(GetFranchiseData query)
        {
            int[] franchiseIds = _repository.GetFranchiseIds(_applicationStateService.CurrentUser.Id);
            string[] franchiseNames = franchiseIds.Select(franchiseId => Constant.Franchise.Find(franchiseId).Name)
                                                  .Distinct()
                                                  .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string franchiseName in franchiseNames)
            {
                var franchise = Constant.Franchise.Find(franchiseName);
                int count = franchiseIds.Count(franchiseId => franchiseId == franchise.Id);

                counts.Add(count);
                labels.Add($"{franchiseName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
