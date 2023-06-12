namespace Memorabilia.Application.Features.Project;

public record GetImportProjectTeamPersons(int TeamId, int Year)
    : IQuery<Entity.Person[]>
{
    public class Handler : QueryHandler<GetImportProjectTeamPersons, Entity.Person[]>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Entity.Person[]> Handle(GetImportProjectTeamPersons query)
            => await _personRepository.GetAll(query.TeamId, query.Year);
    }
}
