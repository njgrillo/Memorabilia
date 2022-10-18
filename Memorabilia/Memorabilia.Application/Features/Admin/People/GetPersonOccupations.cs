namespace Memorabilia.Application.Features.Admin.People;

public record GetPersonOccupations(int PersonId) : IQuery<PersonOccupationViewModel>
{
    public class Handler : QueryHandler<GetPersonOccupations, PersonOccupationViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonOccupationViewModel> Handle(GetPersonOccupations query)
        {
            return new PersonOccupationViewModel(await _personRepository.Get(query.PersonId));
        }
    }
}
