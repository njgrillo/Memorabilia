namespace Memorabilia.Application.Features.User;

public record GetUserById(int UserId) 
    : IQuery<Entity.User>
{
    public class Handler : QueryHandler<GetUserById, Entity.User>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<Entity.User> Handle(GetUserById query)
            => await _userRepository.Get(query.UserId);
    }
}
