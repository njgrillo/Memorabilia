namespace Memorabilia.Application.Features.Project;

public record GetImportProjectPersons(Dictionary<string, object> Parameters)
    : IQuery<Entity.Person[]>
{
    public class Handler(IPersonRepository personRepository) 
        : QueryHandler<GetImportProjectPersons, Entity.Person[]>
    {
        protected override async Task<Entity.Person[]> Handle(GetImportProjectPersons query)
            => await personRepository.GetAll(query.Parameters);
    }
}
