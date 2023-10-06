namespace Memorabilia.Application.Features.User;

public record SaveUserStripeCustomerId(int UserId, string CustomerId)
    : ICommand
{
    public class Handler : CommandHandler<SaveUserStripeCustomerId>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task Handle(SaveUserStripeCustomerId command)
        {
            Entity.User user = await _userRepository.Get(command.UserId);

            user.SetStripeOptions(command.CustomerId);

            await _userRepository.Update(user);
        }
    }
}
