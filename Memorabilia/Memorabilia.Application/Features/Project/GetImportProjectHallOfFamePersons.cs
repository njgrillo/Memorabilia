namespace Memorabilia.Application.Features.Project;

public record GetImportProjectHallOfFamePersons(int SportLeagueLevelId, int? Year)
    : IQuery<Entity.Person[]>
{
    public class Handler : QueryHandler<GetImportProjectHallOfFamePersons, Entity.Person[]>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Entity.Person[]> Handle(GetImportProjectHallOfFamePersons query)
            => await _personRepository.GetAllHallOfFamers(query.SportLeagueLevelId, query.Year);
    }
}
