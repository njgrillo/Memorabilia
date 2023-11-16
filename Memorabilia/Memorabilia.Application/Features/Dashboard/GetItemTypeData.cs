using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Dashboard;

public record GetItemTypeData() : IQuery<DashboardChartModel>
{
    public class Handler(IMemorabiliaItemRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetItemTypeData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetItemTypeData query)
        {
            int[] itemTypeIds 
                = repository.GetItemTypeIds(applicationStateService.CurrentUser.Id);

            string[] itemTypeNames 
                = itemTypeIds.Select(itemTypeId => Constant.ItemType.Find(itemTypeId).Name)
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
