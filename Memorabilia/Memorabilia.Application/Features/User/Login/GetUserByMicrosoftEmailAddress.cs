namespace Memorabilia.Application.Features.User.Login;

public record GetUserByMicrosoftEmailAddress(string EmailAddress) : IQuery<Entity.User>
{
    public class Handler(IUserRepository userRepository) 
        : QueryHandler<GetUserByMicrosoftEmailAddress, Entity.User>
    {
        protected override async Task<Entity.User> Handle(GetUserByMicrosoftEmailAddress query)
            => await userRepository.GetByMicrosoftEmailAddress(query.EmailAddress);
    }
}
