namespace Memorabilia.Application.Features.User;

public record CheckActiveSubscriptions()
     : ICommand
{
    public class Handler : CommandHandler<ProcessExpiredSubscriptions>
    {
        private readonly StripeService _stripeService;
        private readonly IUserRepository _userRepository;

        public Handler(StripeService stripeService,
                       IUserRepository userRepository)
        {
            _stripeService = stripeService;
            _userRepository = userRepository;
        }

        protected override async Task Handle(ProcessExpiredSubscriptions command)
        {
            Entity.User[] activeSubscribedUsers
                = await _userRepository.GetAllByActiveSubscriptions();

            if (!activeSubscribedUsers.Any())
                return;

            foreach (Entity.User user in activeSubscribedUsers)
            {
                Subscription subscription 
                    = await _stripeService.GetSubscriptionAsync(user.StripeSubscriptionId);

                if (subscription == null || (!subscription.CancelAt.HasValue && !subscription.CanceledAt.HasValue)) 
                    continue;

                user.SetSubscriptionExpirationDate(subscription.CanceledAt ?? subscription.CancelAt);
                user.SetSubscriptionStatus(isCanceled: true);

                await _userRepository.Update(user);
            }
        }
    }
}
