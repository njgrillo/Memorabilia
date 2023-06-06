namespace Memorabilia.Application.Features.Dashboard;

public record GetColorData(int UserId) : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetColorData, DashboardChartModel>
    {
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartModel> Handle(GetColorData query)
        {
            var colorIds = _repository.GetColorIds(query.UserId);
            var colorNames = colorIds.Select(colorId => Constant.Color.Find(colorId).Name)
                                     .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var colorName in colorNames)
            {
                var color = Constant.Color.Find(colorName);
                var count = colorIds.Count(colorId => colorId == color.Id);

                counts.Add(count);
                labels.Add($"{colorName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
