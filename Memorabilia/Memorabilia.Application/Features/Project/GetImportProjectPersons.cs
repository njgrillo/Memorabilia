namespace Memorabilia.Application.Features.Project;

public record GetImportProjectPersons(Dictionary<string, object> Parameters)
    : IQuery<Domain.Entities.Person[]>
{
    public class Handler : QueryHandler<GetImportProjectPersons, Domain.Entities.Person[]>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Domain.Entities.Person[]> Handle(GetImportProjectPersons query)
        {
            return await _personRepository.GetAll(query.Parameters);
        }
    }
}
