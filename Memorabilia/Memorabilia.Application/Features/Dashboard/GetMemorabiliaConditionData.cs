using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Dashboard;

public record GetMemorabiliaConditionData() : IQuery<DashboardChartModel>
{
    public class Handler(IMemorabiliaItemRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetMemorabiliaConditionData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetMemorabiliaConditionData query)
        {
            int[] conditionIds 
                = repository.GetConditionIds(applicationStateService.CurrentUser.Id);

            string[] conditionNames 
                = conditionIds.Select(conditionId => Constant.Condition.Find(conditionId).Name)
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
