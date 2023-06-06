namespace Memorabilia.Application.Features.Tools.Profile.Basketball;

public record GetBasketballProfile(int PersonId) : IQuery<BasketballProfileModel>
{
    public class Handler : QueryHandler<GetBasketballProfile, BasketballProfileModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<BasketballProfileModel> Handle(GetBasketballProfile query)
        {
            return new BasketballProfileModel(await _personRepository.Get(query.PersonId));
        }
    }
}
