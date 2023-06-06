namespace Memorabilia.Application.Features.User.Dashboard;

public record GetUserDashboardItems(int UserId) : IQuery<UserDashboardsViewModel>
{
    public class Handler : QueryHandler<GetUserDashboardItems, UserDashboardsViewModel>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<UserDashboardsViewModel> Handle(GetUserDashboardItems query)
        {
            var user = await _userRepository.Get(query.UserId);                

            return new UserDashboardsViewModel(user.Id, 
                                               user.DashboardItems
                                                   .OrderBy(dashboardItem => Constant.DashboardItem.Find(dashboardItem.DashboardItemId).Name));
        }
    }
}
