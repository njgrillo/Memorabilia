namespace Memorabilia.Application.Features.Admin.People;

public record GetPeople(int? SportId = null) : IQuery<PeopleViewModel>
{
    public class Handler : QueryHandler<GetPeople, PeopleViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PeopleViewModel> Handle(GetPeople query)
        {
            return new PeopleViewModel(await _personRepository.GetAll(query.SportId));
        }
    }
}
