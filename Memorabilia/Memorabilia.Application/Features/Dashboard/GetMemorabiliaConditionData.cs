namespace Memorabilia.Application.Features.Dashboard;

public record GetMemorabiliaConditionData() : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetMemorabiliaConditionData, DashboardChartModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository, 
                       IApplicationStateService applicationStateService)
        {
            _repository = repository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<DashboardChartModel> Handle(GetMemorabiliaConditionData query)
        {
            int[] conditionIds = _repository.GetConditionIds(_applicationStateService.CurrentUser.Id);
            string[] conditionNames = conditionIds.Select(conditionId => Constant.Condition.Find(conditionId).Name)
                                                  .Distinct()
                                                  .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string conditionName in conditionNames)
            {
                var condition = Constant.Condition.Find(conditionName);
                int count = conditionIds.Count(conditionId => conditionId == condition.Id);

                counts.Add(count);
                labels.Add($"{conditionName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
