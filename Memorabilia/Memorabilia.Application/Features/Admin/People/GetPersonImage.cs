namespace Memorabilia.Application.Features.Admin.People;

public record GetPersonImage(int PersonId) : IQuery<PersonImageViewModel>
{
    public class Handler : QueryHandler<GetPersonImage, PersonImageViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<PersonImageViewModel> Handle(GetPersonImage query)
        {
            var person = await _personRepository.Get(query.PersonId);

            return new PersonImageViewModel(person);
        }
    }
}
