using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.Dashboard;

public record GetSizeData() : IQuery<DashboardChartModel>
{
    public class Handler(IMemorabiliaItemRepository repository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetSizeData, DashboardChartModel>
    {
        protected override async Task<DashboardChartModel> Handle(GetSizeData query)
        {
            int[] sizeIds = repository.GetSizeIds(applicationStateService.CurrentUser.Id);

            string[] sizeNames 
                = sizeIds.Select(sizeId => Constant.Size.Find(sizeId).Name)
                         .Distinct()
                         .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string sizeName in sizeNames)
            {
                var size = Constant.Size.Find(sizeName);
                int count = sizeIds.Count(sizeId => sizeId == size.Id);

                counts.Add(count);
                labels.Add($"{sizeName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
