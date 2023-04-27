namespace Memorabilia.Application.Features.Memorabilia;

public record GetDashboard(int UserId) : IQuery<DashboardViewModel>
{
    public class Handler : QueryHandler<GetDashboard, DashboardViewModel>
    {
        private readonly IDashboardItemFactory _dashboardItemFactory;
        private readonly IMemorabiliaItemRepository _memorabiliaRepository;
        private readonly IUserRepository _userRepository;

        public Handler(IDashboardItemFactory dashboardItemFactory, 
                       IMemorabiliaItemRepository memorabiliaRepository, 
                       IUserRepository userRepository)
        {
            _dashboardItemFactory = dashboardItemFactory;
            _memorabiliaRepository = memorabiliaRepository;
            _userRepository = userRepository;
        }

        protected override async Task<DashboardViewModel> Handle(GetDashboard query)
        {
            var user = await _userRepository.Get(query.UserId);
            var dashboardItems = user.DashboardItems.Select(userDashboard => Domain.Constants.DashboardItem.Find(userDashboard.DashboardItemId));
            var memorabiliaItems = await _memorabiliaRepository.GetAll(query.UserId);           

            var dashboardItemViewModels = new List<DashboardItemViewModel>();

            foreach (var dashboardItem in dashboardItems)
            {
                foreach (var rule in _dashboardItemFactory.Rules)
                {
                    if (!rule.Applies(dashboardItem))
                        continue;

                    dashboardItemViewModels.Add(rule.Get(memorabiliaItems));
                    break;
                }
            }                

            return new DashboardViewModel(dashboardItemViewModels.OrderBy(dashboardItem => dashboardItem.DashboardItem.Name));
        }
    }
}
