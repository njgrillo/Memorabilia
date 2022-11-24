namespace Memorabilia.Application.Features.Admin.People;

public record GetDomainPeople(int? SportId = null, int? SportLeagueLevelId = null) : IQuery<IEnumerable<Domain.Entities.Person>>
{
    public class Handler : QueryHandler<GetDomainPeople, IEnumerable<Domain.Entities.Person>>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<IEnumerable<Domain.Entities.Person>> Handle(GetDomainPeople query)
        {
            return await _personRepository.GetAll(query.SportId, query.SportLeagueLevelId);
        }
    }
}
