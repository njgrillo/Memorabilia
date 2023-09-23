namespace Memorabilia.Application.Features.User.Login;

public record GetUserByMicrosoftEmailAddress(string EmailAddress) : IQuery<Entity.User>
{
    public class Handler : QueryHandler<GetUserByMicrosoftEmailAddress, Entity.User>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<Entity.User> Handle(GetUserByMicrosoftEmailAddress query)
            => await _userRepository.GetByMicrosoftEmailAddress(query.EmailAddress);
    }
}
