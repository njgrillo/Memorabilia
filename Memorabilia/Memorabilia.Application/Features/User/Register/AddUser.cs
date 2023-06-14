namespace Memorabilia.Application.Features.User.Register;

public record AddUser(UserEditModel User) 
    : ICommand
{
    public bool UserAlreadyExists { get; set; }

    public class Handler : CommandHandler<AddUser>
    {
        private readonly IUserRepository _userRepository;        

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task Handle(AddUser command)
        {
            Entity.User user = await _userRepository.Get(command.User.EmailAddress);

            if (user != null)
            {
                command.UserAlreadyExists = true;
                return;
            }

            user = new Entity.User(command.User.EmailAddress, 
                                   command.User.FirstName, 
                                   command.User.LastName);

            await _userRepository.Add(user);
        }
    }
}
