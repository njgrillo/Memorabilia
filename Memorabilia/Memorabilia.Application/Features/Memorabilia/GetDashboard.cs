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
            var user = await _userRepository.Get(query.UserId);
            var dashboardItems = user.DashboardItems.Select(userDashboard => Constant.DashboardItem.Find(userDashboard.DashboardItemId));
         
            return new DashboardModel(dashboardItems.Select(x => new DashboardItemViewModel { DashboardItem = x }).OrderBy(dashboardItem => dashboardItem.DashboardItem.Name));
        }
    }
}
