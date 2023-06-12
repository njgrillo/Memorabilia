namespace Memorabilia.Application.Features.Admin.Spots;

public record GetSpots() : IQuery<Entity.Spot[]>
{
    public class Handler : QueryHandler<GetSpots, Entity.Spot[]>
    {
        private readonly IDomainRepository<Entity.Spot> _spotRepository;

        public Handler(IDomainRepository<Entity.Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task<Entity.Spot[]> Handle(GetSpots query)
            => (await _spotRepository.GetAll())
                    .ToArray();
    }
}
