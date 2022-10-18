namespace Memorabilia.Application.Features.Admin.People;

public record GetPersonHallOfFames(int PersonId) : IQuery<PersonHallOfFameViewModel>
{
    public class Handler : QueryHandler<GetPersonHallOfFames, PersonHallOfFameViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonHallOfFameViewModel> Handle(GetPersonHallOfFames query)
        {
            return new PersonHallOfFameViewModel(await _personRepository.Get(query.PersonId));
        }
    }
}
