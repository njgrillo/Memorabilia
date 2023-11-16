namespace Memorabilia.Application.Features.Dashboard;

public record GetFranchiseData() : IQuery<DashboardChartModel>
{
    public class Handler(IMemorabiliaItemRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetFranchiseData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetFranchiseData query)
        {
            int[] franchiseIds 
                = repository.GetFranchiseIds(applicationStateService.CurrentUser.Id);

            string[] franchiseNames 
                = franchiseIds.Select(franchiseId => Constant.Franchise.Find(franchiseId).Name)
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
