namespace Memorabilia.Application.Features.User;

public record SaveUser(UserEditModel User) 
    : ICommand
{
    public class Handler : CommandHandler<SaveUser>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task Handle(SaveUser command)
        {
            Entity.User user = await _userRepository.Get(command.User.Id);

            user.SetStripeSubscriptionId(command.User.StripeSubscriptionId);
            user.SetSubscriptionExpirationDate(command.User.SubscriptionExpirationDate);
            user.SetSubscriptionStatus(command.User.SubscriptionCanceled);
            user.SetUserRole(command.User.UserRole.RoleId);   

            await _userRepository.Update(user);
        }
    }
}
