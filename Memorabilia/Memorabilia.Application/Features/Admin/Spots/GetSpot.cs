using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Spots;

public record GetSpot(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetSpot, DomainModel>
    {
        private readonly IDomainRepository<Spot> _spotRepository;

        public Handler(IDomainRepository<Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task<DomainModel> Handle(GetSpot query)
        {
            return new DomainModel(await _spotRepository.Get(query.Id));
        }
    }
}
