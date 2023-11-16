namespace Memorabilia.Application.Features.Admin.Spots;

public record GetSpot(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.Spot> spotRepository) 
        : QueryHandler<GetSpot, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetSpot query)
            => await spotRepository.Get(query.Id);
    }
}
