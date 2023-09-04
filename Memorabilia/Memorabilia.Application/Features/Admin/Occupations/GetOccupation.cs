namespace Memorabilia.Application.Features.Admin.Occupations;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetOccupation(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetOccupation, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.Occupation> _occupationRepository;

        public Handler(IDomainRepository<Entity.Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetOccupation query)
            => await _occupationRepository.Get(query.Id);
    }
}
