namespace Memorabilia.Application.Features.Admin.Sports;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetSport(int Id) : IQuery<Entity.Sport>
{
    public class Handler : QueryHandler<GetSport, Entity.Sport>
    {
        private readonly IDomainRepository<Entity.Sport> _sportRepository;

        public Handler(IDomainRepository<Entity.Sport> sportRepository)
        {
            _sportRepository = sportRepository;
        }

        protected override async Task<Entity.Sport> Handle(GetSport query)
            => await _sportRepository.Get(query.Id);
    }
}
