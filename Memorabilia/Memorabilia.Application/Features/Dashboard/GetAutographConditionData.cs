namespace Memorabilia.Application.Features.Dashboard;

public record GetAutographConditionData() : IQuery<DashboardChartModel>
{
    public class Handler(IAutographRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetAutographConditionData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetAutographConditionData query)
        {
            int[] conditionTypeIds 
                = repository.GetConditionIds(applicationStateService.CurrentUser.Id);

            string[] conditionTypeNames 
                = conditionTypeIds.Select(conditionTypeId => Constant.Condition.Find(conditionTypeId).Name)
                                  .Distinct()
                                  .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string conditionTypeName in conditionTypeNames)
            {
                var conditionType = Constant.Condition.Find(conditionTypeName);
                int count = conditionTypeIds.Count(conditionTypeId => conditionTypeId == conditionType.Id);

                counts.Add(count);
                labels.Add($"{conditionTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
