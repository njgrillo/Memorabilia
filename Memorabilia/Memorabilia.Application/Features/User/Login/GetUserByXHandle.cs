namespace Memorabilia.Application.Features.User.Login;

public record GetUserByXHandle(string Handle) : IQuery<Entity.User>
{
    public class Handler : QueryHandler<GetUserByXHandle, Entity.User>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<Entity.User> Handle(GetUserByXHandle query)
            => await _userRepository.GetByXHandle(query.Handle);
    }
}
