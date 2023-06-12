namespace Memorabilia.Application.Features.Project;

public record GetImportProjectPersons(Dictionary<string, object> Parameters)
    : IQuery<Entity.Person[]>
{
    public class Handler : QueryHandler<GetImportProjectPersons, Entity.Person[]>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Entity.Person[]> Handle(GetImportProjectPersons query)
            => await _personRepository.GetAll(query.Parameters);
    }
}
