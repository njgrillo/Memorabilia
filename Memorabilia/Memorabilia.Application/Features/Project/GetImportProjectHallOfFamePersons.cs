namespace Memorabilia.Application.Features.Project;

public record GetImportProjectHallOfFamePersons(int SportLeagueLevelId, int? Year)
    : IQuery<Domain.Entities.Person[]>
{
    public class Handler : QueryHandler<GetImportProjectHallOfFamePersons, Domain.Entities.Person[]>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Domain.Entities.Person[]> Handle(GetImportProjectHallOfFamePersons query)
        {
            return await _personRepository.GetAllHallOfFamers(query.SportLeagueLevelId, query.Year);
        }
    }
}
