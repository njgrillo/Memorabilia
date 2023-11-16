namespace Memorabilia.Application.Features.User;

public record GetUser(string EmailAddress) : IQuery<Entity.User>
{
    public class Handler(IUserRepository userRepository) 
        : QueryHandler<GetUser, Entity.User>
    {
        protected override async Task<Entity.User> Handle(GetUser query)
            => await userRepository.Get(query.EmailAddress);
    }
}
