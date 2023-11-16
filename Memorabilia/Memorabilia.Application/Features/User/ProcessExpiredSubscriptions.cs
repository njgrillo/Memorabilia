namespace Memorabilia.Application.Features.User;

public record ProcessExpiredSubscriptions()
     : ICommand
{
    public class Handler(IUserRepository userRepository) 
        : CommandHandler<ProcessExpiredSubscriptions>
    {
        protected override async Task Handle(ProcessExpiredSubscriptions command)
        {
            Entity.User[] expiredSubscriptionUsers
                = await userRepository.GetAllBySubscriptionExpired();

            if (expiredSubscriptionUsers.IsNullOrEmpty())
                return;

            foreach (Entity.User user in expiredSubscriptionUsers)
            {
                user.SetUserRole(Constant.Role.NonSubscriber.Id);

                await userRepository.Update(user);
            }
        }
    }
}
