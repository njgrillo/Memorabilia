namespace Memorabilia.Application.Features.User
{
    public class GetUser
    {
        public class Handler : QueryHandler<Query, UserViewModel>
        {
            private readonly IUserRepository _userRepository;

            public Handler(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            protected override async Task<UserViewModel> Handle(Query query)
            {
                return new UserViewModel(await _userRepository.Get(query.Username, query.Password).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<UserViewModel>
        {
            public Query(string username, string password)
            {
                Username = username;
                Password = password;
            }

            public string Password { get; }

            public string Username { get; }
        }
    }
}
