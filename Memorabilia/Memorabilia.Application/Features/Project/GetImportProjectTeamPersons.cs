namespace Memorabilia.Application.Features.Project;

public record GetImportProjectTeamPersons(int TeamId, int Year)
    : IQuery<Domain.Entities.Person[]>
{
    public class Handler : QueryHandler<GetImportProjectTeamPersons, Domain.Entities.Person[]>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Domain.Entities.Person[]> Handle(GetImportProjectTeamPersons query)
        {
            return await _personRepository.GetAll(query.TeamId, query.Year);
        }
    }
}
