using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Spots;

public record GetSpot(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetSpot, DomainViewModel>
    {
        private readonly IDomainRepository<Spot> _spotRepository;

        public Handler(IDomainRepository<Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetSpot query)
        {
            return new DomainViewModel(await _spotRepository.Get(query.Id));
        }
    }
}
