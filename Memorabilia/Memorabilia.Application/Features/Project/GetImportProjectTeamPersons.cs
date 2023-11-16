namespace Memorabilia.Application.Features.Project;

public record GetImportProjectTeamPersons(int TeamId, int Year)
    : IQuery<Entity.Person[]>
{
    public class Handler(IPersonRepository personRepository) 
        : QueryHandler<GetImportProjectTeamPersons, Entity.Person[]>
    {
        protected override async Task<Entity.Person[]> Handle(GetImportProjectTeamPersons query)
            => await personRepository.GetAll(query.TeamId, query.Year);
    }
}
