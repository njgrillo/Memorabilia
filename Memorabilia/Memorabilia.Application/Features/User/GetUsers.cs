namespace Memorabilia.Application.Features.User;

public record GetUsers() : IQuery<Entity.User[]>
{
    public class Handler(IUserRepository userRepository) 
        : QueryHandler<GetUsers, Entity.User[]>
    {
        protected override async Task<Entity.User[]> Handle(GetUsers query)
            => await userRepository.GetAll();
    }
}
