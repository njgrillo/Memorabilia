namespace Memorabilia.Application.Features.Admin.People;

public record GetPersonTeams(int PersonId) : IQuery<PersonTeamsViewModel>
{
    public class Handler : QueryHandler<GetPersonTeams, PersonTeamsViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonTeamsViewModel> Handle(GetPersonTeams query)
        {
            return new PersonTeamsViewModel(await _personRepository.Get(query.PersonId));
        }
    }
}
