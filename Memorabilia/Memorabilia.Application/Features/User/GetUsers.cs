namespace Memorabilia.Application.Features.User;

public record GetUsers() : IQuery<Entity.User[]>
{
    public class Handler : QueryHandler<GetUsers, Entity.User[]>
    {
        private readonly IUserRepository _userRepository;

        public Handler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected override async Task<Entity.User[]> Handle(GetUsers query)
            => await _userRepository.GetAll();
    }
}
