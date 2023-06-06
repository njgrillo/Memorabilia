﻿namespace Memorabilia.Application.Features.Dashboard;

public record GetItemTypeData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetItemTypeData, DashboardChartModel>
    {
        private readonly IMemorabiliaItemRepository _repository;

        public Handler(IMemorabiliaItemRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetItemTypeData query)
        {
            var itemTypeIds = _repository.GetItemTypeIds(query.UserId);
            var itemTypeNames = itemTypeIds.Select(itemTypeId => Constant.ItemType.Find(itemTypeId).Name)
                                           .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var itemTypeName in itemTypeNames)
            {
                var itemType = Constant.ItemType.Find(itemTypeName);
                var count = itemTypeIds.Count(itemTypeId => itemTypeId == itemType.Id);

                counts.Add(count);
                labels.Add($"{itemTypeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
