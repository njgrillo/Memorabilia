namespace Memorabilia.Application.Features.Memorabilia;

public record GetDashboard(int UserId) 
    : IQuery<DashboardModel>
{
    public class Handler : QueryHandler<GetDashboard, DashboardModel>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<DashboardModel> Handle(GetDashboard query)
        {
            Entity.User user = await _userRepository.Get(query.UserId);

            IEnumerable<Constant.DashboardItem> dashboardItems 
                = user.DashboardItems.Select(userDashboard => Constant.DashboardItem.Find(userDashboard.DashboardItemId));
         
            return new DashboardModel(dashboardItems.Select(x => new Dashboard.DashboardItemModel { DashboardItem = x })
                                                    .OrderBy(dashboardItem => dashboardItem.DashboardItem.Name));
        }
    }
}
