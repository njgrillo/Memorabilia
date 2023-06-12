namespace Memorabilia.Application.Features.User.Dashboard;

public class SaveUserDashboard
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task Handle(Command command)
        {
            Entity.User user = await _userRepository.Get(command.UserId);

            user.SetDashboardItems(command.DashboardItemIds);

            await _userRepository.Update(user);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly UserDashboardEditModel _editModel;

        public Command(UserDashboardEditModel editModel)
        {
            _editModel = editModel;
        }

        public int[] DashboardItemIds 
            => _editModel.UserDashboardItems
                         .Where(userDashboardItem => userDashboardItem.IsSelected)
                         .Select(userDashboardItem => userDashboardItem.DashboardItemId)
                         .ToArray();

        public int UserId 
            => _editModel.UserId;
    }
}
