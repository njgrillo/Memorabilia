namespace Memorabilia.Application.Features.User;

public record ProcessExpiredSubscriptions()
     : ICommand
{
    public class Handler : CommandHandler<ProcessExpiredSubscriptions>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task Handle(ProcessExpiredSubscriptions command)
        {
            Entity.User[] expiredSubscriptionUsers
                = await _userRepository.GetAllBySubscriptionExpired();

            if (!expiredSubscriptionUsers.Any())
                return;

            foreach (Entity.User user in expiredSubscriptionUsers)
            {
                user.SetUserRole(Constant.Role.NonSubscriber.Id);

                await _userRepository.Update(user);
            }
        }
    }
}
