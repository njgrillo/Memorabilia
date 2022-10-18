namespace Memorabilia.Application.Features.Admin.People;

public record GetPerson(int Id) : IQuery<PersonViewModel>
{
    public class Handler : QueryHandler<GetPerson, PersonViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonViewModel> Handle(GetPerson query)
        {
            return new PersonViewModel(await _personRepository.Get(query.Id));
        }
    }
}
