namespace Memorabilia.Application.Features.User.Login;

public record GetUserByGoogleEmailAddress(string EmailAddress) : IQuery<Entity.User>
{
    public class Handler : QueryHandler<GetUserByGoogleEmailAddress, Entity.User>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<Entity.User> Handle(GetUserByGoogleEmailAddress query)
            => await _userRepository.GetByGoogleEmailAddress(query.EmailAddress);
    }
}
