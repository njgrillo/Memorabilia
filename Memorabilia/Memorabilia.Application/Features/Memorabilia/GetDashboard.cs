namespace Memorabilia.Application.Features.Memorabilia;

public record GetDashboard() 
    : IQuery<DashboardModel>
{
    public class Handler : QueryHandler<GetDashboard, DashboardModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository, 
                       IApplicationStateService applicationStateService)
        {
            _userRepository = userRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task<DashboardModel> Handle(GetDashboard query)
        {
            Entity.User user = await _userRepository.Get(_applicationStateService.CurrentUser.Id);

            IEnumerable<Constant.DashboardItem> dashboardItems 
                = user.DashboardItems.Select(userDashboard => Constant.DashboardItem.Find(userDashboard.DashboardItemId));
         
            return new DashboardModel(dashboardItems.Select(x => new Dashboard.DashboardItemModel { DashboardItem = x })
                                                    .OrderBy(dashboardItem => dashboardItem.DashboardItem.Name));
        }
    }
}
