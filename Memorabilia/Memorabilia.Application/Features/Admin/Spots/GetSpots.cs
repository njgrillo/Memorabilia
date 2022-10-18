using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Spots;

public record GetSpots() : IQuery<SpotsViewModel>
{
    public class Handler : QueryHandler<GetSpots, SpotsViewModel>
    {
        private readonly IDomainRepository<Spot> _spotRepository;

        public Handler(IDomainRepository<Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task<SpotsViewModel> Handle(GetSpots query)
        {
            return new SpotsViewModel(await _spotRepository.GetAll());
        }
    }
}
