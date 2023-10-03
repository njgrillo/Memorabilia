namespace Memorabilia.Application.Features.Admin.Spots;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetSpot(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetSpot, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.Spot> _spotRepository;

        public Handler(IDomainRepository<Entity.Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetSpot query)
            => await _spotRepository.Get(query.Id);
    }
}
