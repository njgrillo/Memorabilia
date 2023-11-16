namespace Memorabilia.Application.Features.User.Register;

public record AddUser(UserEditModel User) 
    : ICommand
{
    public bool UserAlreadyExists { get; set; }

    public class Handler(IUserRepository userRepository) 
        : CommandHandler<AddUser>
    {
        protected override async Task Handle(AddUser command)
        {
            Entity.User user = await userRepository.Get(command.User.EmailAddress);

            if (user != null)
            {
                command.UserAlreadyExists = true;
                return;
            }

            user = await userRepository.GetByUsername(command.User.Username);

            if (user != null)
            {
                command.UserAlreadyExists = true;
                return;
            }

            user = new Entity.User(command.User.EmailAddress, 
                                   command.User.FirstName, 
                                   command.User.LastName,
                                   command.User.Username);

            user.SetUserSettings(useDarkTheme: false,
                                 command.User.GoogleEmailAddress,
                                 command.User.MicrosoftEmailAddress,
                                 command.User.XHandle);

            user.SetShippingAddress(command.User.ShippingAddress.AddressLine1,
                                    command.User.ShippingAddress.AddressLine2,
                                    command.User.ShippingAddress.City,
                                    command.User.ShippingAddress.Country,
                                    command.User.ShippingAddress.PostalCode,
                                    command.User.ShippingAddress.SingleLine,
                                    command.User.ShippingAddress.StateProvidence);

            await userRepository.Add(user);

            command.User.Id = user.Id;
        }
    }
}
