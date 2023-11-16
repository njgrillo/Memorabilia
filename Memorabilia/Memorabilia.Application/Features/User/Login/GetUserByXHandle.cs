namespace Memorabilia.Application.Features.User.Login;

public record GetUserByXHandle(string Handle) : IQuery<Entity.User>
{
    public class Handler(IUserRepository userRepository) 
        : QueryHandler<GetUserByXHandle, Entity.User>
    {
        protected override async Task<Entity.User> Handle(GetUserByXHandle query)
            => await userRepository.GetByXHandle(query.Handle);
    }
}
