namespace Memorabilia.Application.Features.Dashboard;

public record GetMemorabiliaConditionData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetMemorabiliaConditionData, DashboardChartViewModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetMemorabiliaConditionData query)
        {
            var conditionIds = _repository.GetConditionIds(query.UserId);
            var conditionNames = conditionIds.Select(conditionId => Domain.Constants.Condition.Find(conditionId).Name)
                                             .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var conditionName in conditionNames)
            {
                var condition = Domain.Constants.Condition.Find(conditionName);
                var count = conditionIds.Count(conditionId => conditionId == condition.Id);

                counts.Add(count);
                labels.Add($"{conditionName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
