namespace Memorabilia.Application.Features.Memorabilia;

public record GetDashboard() 
    : IQuery<DashboardModel>
{
    public class Handler(IUserRepository userRepository,
                         IApplicationStateService applicationStateService) 
        : QueryHandler<GetDashboard, DashboardModel>
    {
        protected override async Task<DashboardModel> Handle(GetDashboard query)
        {
            Entity.User user = await userRepository.Get(applicationStateService.CurrentUser.Id);

            IEnumerable<Constant.DashboardItem> dashboardItems 
                = user.DashboardItems.Select(userDashboard => Constant.DashboardItem.Find(userDashboard.DashboardItemId));
         
            return new DashboardModel(dashboardItems.Select(x => new Dashboard.DashboardItemModel { DashboardItem = x })
                                                    .OrderBy(dashboardItem => dashboardItem.DashboardItem.Name));
        }
    }
}
