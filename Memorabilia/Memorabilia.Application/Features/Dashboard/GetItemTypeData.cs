namespace Memorabilia.Application.Features.Dashboard;

public record GetItemTypeData() : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetItemTypeData, DashboardChartModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository, 
                       IApplicationStateService applicationStateService)
        {
            _repository = repository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<DashboardChartModel> Handle(GetItemTypeData query)
        {
            int[] itemTypeIds = _repository.GetItemTypeIds(_applicationStateService.CurrentUser.Id);
            string[] itemTypeNames = itemTypeIds.Select(itemTypeId => Constant.ItemType.Find(itemTypeId).Name)
                                                .Distinct()
                                                .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string itemTypeName in itemTypeNames)
            {
                var itemType = Constant.ItemType.Find(itemTypeName);
                int count = itemTypeIds.Count(itemTypeId => itemTypeId == itemType.Id);

                counts.Add(count);
                labels.Add($"{itemTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
