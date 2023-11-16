namespace Memorabilia.Application.Features.User;

public record CheckActiveSubscriptions()
     : ICommand
{
    public class Handler(StripeService stripeService,
                         IUserRepository userRepository) 
        : CommandHandler<ProcessExpiredSubscriptions>
    {
        protected override async Task Handle(ProcessExpiredSubscriptions command)
        {
            Entity.User[] activeSubscribedUsers
                = await userRepository.GetAllByActiveSubscriptions();

            if (activeSubscribedUsers.IsNullOrEmpty())
                return;

            foreach (Entity.User user in activeSubscribedUsers)
            {
                Subscription subscription 
                    = await stripeService.GetSubscriptionAsync(user.StripeSubscriptionId);

                if (subscription == null || (!subscription.CancelAt.HasValue && !subscription.CanceledAt.HasValue)) 
                    continue;

                user.SetSubscriptionExpirationDate(subscription.CanceledAt ?? subscription.CancelAt);
                user.SetSubscriptionStatus(isCanceled: true);

                await userRepository.Update(user);
            }
        }
    }
}
