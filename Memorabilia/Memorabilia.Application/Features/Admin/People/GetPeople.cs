namespace Memorabilia.Application.Features.Admin.People;

public record GetPeople(int? SportId = null, 
                        int? SportLeagueLevelId = null) 
    : IQuery<Entity.Person[]>
{
    public class Handler : QueryHandler<GetPeople, Entity.Person[]>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Entity.Person[]> Handle(GetPeople query)
            => (await _personRepository.GetAll(query.SportId, query.SportLeagueLevelId))
                    .ToArray();
    }
}
