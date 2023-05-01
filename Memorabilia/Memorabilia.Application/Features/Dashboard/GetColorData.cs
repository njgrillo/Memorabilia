namespace Memorabilia.Application.Features.Dashboard;

public record GetColorData(int UserId) : IQuery<DashboardChartViewModel>
{
    public class Handler : QueryHandler<GetColorData, DashboardChartViewModel>
    {
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository)
        {
            _repository = repository;
        }

        protected override async Task<DashboardChartViewModel> Handle(GetColorData query)
        {
            var colorIds = _repository.GetColorIds(query.UserId);
            var colorNames = colorIds.Select(colorId => Domain.Constants.Color.Find(colorId).Name)
                                     .Distinct();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (var colorName in colorNames)
            {
                var color = Domain.Constants.Color.Find(colorName);
                var count = colorIds.Count(colorId => colorId == color.Id);

                counts.Add(count);
                labels.Add($"{colorName} ({count})");
            }

            return await Task.FromResult(new DashboardChartViewModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
