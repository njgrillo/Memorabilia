namespace Memorabilia.Application.Features.User.Dashboard;

public class GetUserDashboardItems
{
    public class Handler : QueryHandler<Query, UserDashboardsViewModel>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<UserDashboardsViewModel> Handle(Query query)
        {
            var user = await _userRepository.Get(query.UserId);                

            return new UserDashboardsViewModel(user.Id, 
                                               user.DashboardItems
                                                   .OrderBy(dashboardItem => Domain.Constants.DashboardItem.Find(dashboardItem.DashboardItemId).Name));
        }
    }

    public class Query : IQuery<UserDashboardsViewModel>
    {
        public Query(int userId) 
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}
