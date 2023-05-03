namespace Memorabilia.Application.Features.Dashboard;

public record GetItemTypeData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetItemTypeData, DashboardChartViewModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetItemTypeData query)
        {
            var itemTypeIds = _repository.GetItemTypeIds(query.UserId);
            var itemTypeNames = itemTypeIds.Select(itemTypeId => Domain.Constants.ItemType.Find(itemTypeId).Name)
                                           .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var itemTypeName in itemTypeNames)
            {
                var itemType = Domain.Constants.ItemType.Find(itemTypeName);
                var count = itemTypeIds.Count(itemTypeId => itemTypeId == itemType.Id);

                counts.Add(count);
                labels.Add($"{itemTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
