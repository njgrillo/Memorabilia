namespace Memorabilia.Application.Features.Dashboard;

public record GetAutographConditionData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetAutographConditionData, DashboardChartModel>
    {
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetAutographConditionData query)
        {
            int[] conditionTypeIds = _repository.GetConditionIds(query.UserId);
            string[] conditionTypeNames = conditionTypeIds.Select(conditionTypeId => Constant.Condition.Find(conditionTypeId).Name)
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
