namespace Memorabilia.Application.Features.User;

public record GetUserById(int UserId) 
    : IQuery<Entity.User>
{
    public class Handler(IUserRepository userRepository) 
        : QueryHandler<GetUserById, Entity.User>
    {
        protected override async Task<Entity.User> Handle(GetUserById query)
            => await userRepository.Get(query.UserId);
    }
}
