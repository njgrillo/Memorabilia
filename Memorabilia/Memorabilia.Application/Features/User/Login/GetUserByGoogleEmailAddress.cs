namespace Memorabilia.Application.Features.User.Login;

public record GetUserByGoogleEmailAddress(string EmailAddress) : IQuery<Entity.User>
{
    public class Handler(IUserRepository userRepository) 
        : QueryHandler<GetUserByGoogleEmailAddress, Entity.User>
    {
        protected override async Task<Entity.User> Handle(GetUserByGoogleEmailAddress query)
            => await userRepository.GetByGoogleEmailAddress(query.EmailAddress);
    }
}
