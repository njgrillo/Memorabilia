using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia;

public record GetDashboard(int UserId) : IQuery<DashboardViewModel>
{
    public class Handler : QueryHandler<GetDashboard, DashboardViewModel>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<DashboardViewModel> Handle(GetDashboard query)
        {
            var user = await _userRepository.Get(query.UserId);
            var dashboardItems = user.DashboardItems.Select(userDashboard => DashboardItem.Find(userDashboard.DashboardItemId));
         
            return new DashboardViewModel(dashboardItems.Select(x => new DashboardItemViewModel { DashboardItem = x }).OrderBy(dashboardItem => dashboardItem.DashboardItem.Name));
        }
    }
}
