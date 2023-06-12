namespace Memorabilia.Application.Features.Admin.Spots;

public record GetSpot(int Id) : IQuery<Entity.Spot>
{
    public class Handler : QueryHandler<GetSpot, Entity.Spot>
    {
        private readonly IDomainRepository<Entity.Spot> _spotRepository;

        public Handler(IDomainRepository<Entity.Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task<Entity.Spot> Handle(GetSpot query)
            => await _spotRepository.Get(query.Id);
    }
}
