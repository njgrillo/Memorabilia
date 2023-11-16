namespace Memorabilia.Application.Features.User;

public record SaveUserStripeCustomerId(int UserId, string CustomerId)
    : ICommand
{
    public class Handler(IUserRepository userRepository) 
        : CommandHandler<SaveUserStripeCustomerId>
    {
        protected override async Task Handle(SaveUserStripeCustomerId command)
        {
            Entity.User user = await userRepository.Get(command.UserId);

            user.SetStripeOptions(command.CustomerId);

            await userRepository.Update(user);
        }
    }
}
