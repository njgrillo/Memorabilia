namespace Memorabilia.Application.Features.User.Register;

public class AddUser
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
            var user = await _userRepository.Get(command.Username, command.Password);

            if (user != null)
            {
                //TODO: user already exists
                return;
            }

            user = new Domain.Entities.User(command.Username, command.Password, command.EmailAddress, command.FirstName, command.LastName, command.Phone);

            await _userRepository.Add(user);

            command.Id = user.Id;
        }

        //private static string EncodePassword(string password)
        //{
        //    return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        //}
    }

    public class Command : DomainCommand, ICommand
    {
        private readonly SaveUserViewModel _viewModel;

        public Command(SaveUserViewModel viewModel)
        {
            _viewModel = viewModel;
            Id = viewModel.Id;
        }

        public string EmailAddress => _viewModel.EmailAddress;

        public string FirstName => _viewModel.FirstName;

        public int Id { get; set; }

        public string LastName => _viewModel.LastName;

        public string Password => _viewModel.Password;

        public string Phone => _viewModel.Phone;

        public string Username => _viewModel.Username;
    }
}
