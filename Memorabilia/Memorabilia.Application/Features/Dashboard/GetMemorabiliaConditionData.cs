namespace Memorabilia.Application.Features.Dashboard;

public record GetMemorabiliaConditionData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetMemorabiliaConditionData, DashboardChartModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetMemorabiliaConditionData query)
        {
            int[] conditionIds = _repository.GetConditionIds(query.UserId);
            string[] conditionNames = conditionIds.Select(conditionId => Constant.Condition.Find(conditionId).Name)
                                                  .Distinct()
                                                  .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string conditionName in conditionNames)
            {
                var condition = Constant.Condition.Find(conditionName);
                var count = conditionIds.Count(conditionId => conditionId == condition.Id);

                counts.Add(count);
                labels.Add($"{conditionName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
