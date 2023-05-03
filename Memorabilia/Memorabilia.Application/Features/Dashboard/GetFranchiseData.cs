namespace Memorabilia.Application.Features.Dashboard;

public record GetFranchiseData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetFranchiseData, DashboardChartViewModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetFranchiseData query)
        {
            var franchiseIds = _repository.GetFranchiseIds(query.UserId);
            var franchiseNames = franchiseIds.Select(franchiseId => Domain.Constants.Franchise.Find(franchiseId).Name)
                                             .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var franchiseName in franchiseNames)
            {
                var franchise = Domain.Constants.Franchise.Find(franchiseName);
                var count = franchiseIds.Count(franchiseId => franchiseId == franchise.Id);

                counts.Add(count);
                labels.Add($"{franchiseName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
