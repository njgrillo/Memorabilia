namespace Memorabilia.Application.Features.Dashboard;

public record GetColorData() : IQuery<DashboardChartModel>
{
    public class Handler : QueryHandler<GetColorData, DashboardChartModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IAutographRepository _repository;

        public Handler(IAutographRepository repository, 
                       IApplicationStateService applicationStateService)
        {
            _repository = repository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<DashboardChartModel> Handle(GetColorData query)
        {
            int[] colorIds = _repository.GetColorIds(_applicationStateService.CurrentUser.Id);
            string[] colorNames = colorIds.Select(colorId => Constant.Color.Find(colorId).Name)
                                          .Distinct()
                                          .ToArray();

            var labels = new List<string>();
            var counts = new List<double>();

            foreach (string colorName in colorNames)
            {
                Constant.Color color = Constant.Color.Find(colorName);
                int count = colorIds.Count(colorId => colorId == color.Id);

                counts.Add(count);
                labels.Add($"{colorName} ({count})");
            }

            return await Task.FromResult(new DashboardChartModel(counts.ToArray(), labels.ToArray()));
        }
    }
}
