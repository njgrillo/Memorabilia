namespace Memorabilia.Application.Features.Dashboard;

public record GetFranchiseData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetFranchiseData, DashboardChartModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetFranchiseData query)
        {
            var franchiseIds = _repository.GetFranchiseIds(query.UserId);
            var franchiseNames = franchiseIds.Select(franchiseId => Constant.Franchise.Find(franchiseId).Name)
                                             .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var franchiseName in franchiseNames)
            {
                var franchise = Constant.Franchise.Find(franchiseName);
                var count = franchiseIds.Count(franchiseId => franchiseId == franchise.Id);

                counts.Add(count);
                labels.Add($"{franchiseName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
