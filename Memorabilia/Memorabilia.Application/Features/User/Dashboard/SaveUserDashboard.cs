namespace Memorabilia.Application.Features.User.Dashboard;

public class SaveUserDashboard
{
    public class Handler(IUserRepository userRepository,
                         IApplicationStateService applicationStateService) 
        : CommandHandler<Command>
    {
        protected override async Task Handle(Command command)
        {
            Entity.User user = await userRepository.Get(applicationStateService.CurrentUser.Id);

            user.SetDashboardItems(command.DashboardItemIds);

            await userRepository.Update(user);
        }
    }

    public class Command(UserDashboardEditModel editModel) 
        : DomainCommand, ICommand
    {
        public int[] DashboardItemIds 
            => editModel.UserDashboardItems
                        .Where(userDashboardItem => userDashboardItem.IsSelected)
                        .Select(userDashboardItem => userDashboardItem.DashboardItemId)
                        .ToArray();
    }
}
