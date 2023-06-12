namespace Memorabilia.Application.Features.User;

public record GetUser(string Username, string Password) : IQuery<Entity.User>
{
    public class Handler : QueryHandler<GetUser, Entity.User>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<Entity.User> Handle(GetUser query)
            => await _userRepository.Get(query.Username, query.Password);
    }
}
