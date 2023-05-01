namespace Memorabilia.Application.Features.Dashboard;

public record GetAutographConditionData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetAutographConditionData, DashboardChartViewModel>
    {
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetAutographConditionData query)
        {
            var conditionTypeIds = _repository.GetConditionIds(query.UserId);
            var conditionTypeNames = conditionTypeIds.Select(conditionTypeId => Domain.Constants.Condition.Find(conditionTypeId).Name)
                                                     .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var conditionTypeName in conditionTypeNames)
            {
                var conditionType = Domain.Constants.Condition.Find(conditionTypeName);
                var count = conditionTypeIds.Count(conditionTypeId => conditionTypeId == conditionType.Id);

                counts.Add(count);
                labels.Add($"{conditionTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
