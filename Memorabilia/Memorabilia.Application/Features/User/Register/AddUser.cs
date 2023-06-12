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
            Entity.User user = await _userRepository.Get(command.Username, command.Password);

            if (user != null)
            {
                //TODO: user already exists
                return;
            }

            user = new Entity.User(command.Username, command.Password, command.EmailAddress, command.FirstName, command.LastName, command.Phone);

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
        private readonly UserEditModel _editModel;

        public Command(UserEditModel editModel)
        {
            _editModel = editModel;
            Id = editModel.Id;
        }

        public string EmailAddress 
            => _editModel.EmailAddress;

        public string FirstName 
            => _editModel.FirstName;

        public int Id { get; set; }

        public string LastName 
            => _editModel.LastName;

        public string Password 
            => _editModel.Password;

        public string Phone 
            => _editModel.Phone;

        public string Username 
            => _editModel.Username;
    }
}
