namespace Memorabilia.Application.Features.Admin.People;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetRecentPersonOccupations() : IQuery<Entity.Person[]>
{
    public class Handler : QueryHandler<GetRecentPersonOccupations, Entity.Person[]>
    {
        private readonly IPersonRepository _personRepository;

        public Handler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        protected override async Task<Entity.Person[]> Handle(GetRecentPersonOccupations query)
            => (await _personRepository.GetMostRecent())
                    .ToArray();
    }
}
