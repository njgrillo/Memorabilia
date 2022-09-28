namespace Memorabilia.Application.Features.Memorabilia
{
    public class GetDashboard
    {
        public class Handler : QueryHandler<Query, DashboardViewModel>
        {
            private readonly IDashboardItemFactory _dashboardItemFactory;
            private readonly IMemorabiliaRepository _memorabiliaRepository;
            private readonly IUserRepository _userRepository;

            public Handler(IDashboardItemFactory dashboardItemFactory, 
                           IMemorabiliaRepository memorabiliaRepository, 
                           IUserRepository userRepository)
            {
                _dashboardItemFactory = dashboardItemFactory;
                _memorabiliaRepository = memorabiliaRepository;
                _userRepository = userRepository;
            }

            protected override async Task<DashboardViewModel> Handle(Query query)
            {
                var user = await _userRepository.Get(query.UserId).ConfigureAwait(false);
                var memorabiliaItems = await _memorabiliaRepository.GetAll(query.UserId).ConfigureAwait(false);
                var dashboardItems = user.DashboardItems.Select(userDashboard => Domain.Constants.DashboardItem.Find(userDashboard.DashboardItemId));

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

        public class Query : IQuery<DashboardViewModel>
        {
            public Query(int userId)
            {
                UserId = userId;
            }

            public int UserId { get; }
        }
    }
}
