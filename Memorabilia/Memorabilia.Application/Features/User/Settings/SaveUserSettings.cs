namespace Memorabilia.Application.Features.User.Settings;

public class SaveUserSettings
{
    public class Handler : CommandHandler<Command>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository,
                       IApplicationStateService applicationStateService)
        {
            _userRepository = userRepository;
            _applicationStateService = applicationStateService;
        }

        protected override async Task Handle(Command command)
        {
            Entity.User user = await _userRepository.Get(_applicationStateService.CurrentUser.Id);

            user.SetUserSettings(command.UseDarkTheme);

            await _userRepository.Update(user);
        }
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly UserSettingsEditModel _editModel;

        public Command(UserSettingsEditModel editModel)
        {
            _editModel = editModel;
        }

        public bool UseDarkTheme
            => _editModel.UseDarkTheme;
    }
}
