namespace Memorabilia.Application.Features.User;

public record SaveUser(UserEditModel User) 
    : ICommand
{
    public class Handler(IUserRepository userRepository) 
        : CommandHandler<SaveUser>
    {
        protected override async Task Handle(SaveUser command)
        {
            Entity.User user = await userRepository.Get(command.User.Id);

            user.SetStripeSubscriptionId(command.User.StripeSubscriptionId);
            user.SetSubscriptionExpirationDate(command.User.SubscriptionExpirationDate);
            user.SetSubscriptionStatus(command.User.SubscriptionCanceled);
            user.SetUserRole(command.User.UserRole.RoleId);   

            await userRepository.Update(user);
        }
    }
}
