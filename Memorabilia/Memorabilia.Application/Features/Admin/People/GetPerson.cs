namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetPerson(int Id) 
    : IQuery<Entity.Person>
{
    public class Handler : QueryHandler<GetPerson, Entity.Person>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Entity.Person> Handle(GetPerson query)
        {
            return await _personRepository.Get(query.Id);
        }
    }
}
