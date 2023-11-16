namespace Memorabilia.Application.Features.Admin.Spots;

public record GetSpots() : IQuery<Entity.Spot[]>
{
    public class Handler(IDomainRepository<Entity.Spot> spotRepository) 
        : QueryHandler<GetSpots, Entity.Spot[]>
    {
        protected override async Task<Entity.Spot[]> Handle(GetSpots query)
            => await spotRepository.GetAll();
    }
}
