namespace Memorabilia.Application.Features.Project;

public record GetImportProjectHallOfFamePersons(int SportLeagueLevelId, int? Year)
    : IQuery<Entity.Person[]>
{
    public class Handler(IPersonRepository personRepository) 
        : QueryHandler<GetImportProjectHallOfFamePersons, Entity.Person[]>
    {
        protected override async Task<Entity.Person[]> Handle(GetImportProjectHallOfFamePersons query)
            => await personRepository.GetAllHallOfFamers(query.SportLeagueLevelId, query.Year);
    }
}
