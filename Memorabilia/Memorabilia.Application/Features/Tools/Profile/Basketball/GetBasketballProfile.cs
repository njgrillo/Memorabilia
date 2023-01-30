namespace Memorabilia.Application.Features.Tools.Profile.Basketball;

public class GetBasketballProfile
{
    public class Handler : QueryHandler<Query, BasketballProfileViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<BasketballProfileViewModel> Handle(Query query)
        {
            return new BasketballProfileViewModel(await _personRepository.Get(query.PersonId));
        }
    }

    public class Query : IQuery<BasketballProfileViewModel>
    {
        public Query(int personId)
        {
            PersonId = personId;
        }

        public int PersonId { get; }
    }
}
