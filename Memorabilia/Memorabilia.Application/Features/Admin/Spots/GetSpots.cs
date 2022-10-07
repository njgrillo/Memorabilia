using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Spots;

public class GetSpots
{
    public class Handler : QueryHandler<Query, SpotsViewModel>
    {
        private readonly IDomainRepository<Spot> _spotRepository;

        public Handler(IDomainRepository<Spot> spotRepository)
        {
            _spotRepository = spotRepository;
        }

        protected override async Task<SpotsViewModel> Handle(Query query)
        {
            return new SpotsViewModel(await _spotRepository.GetAll());
        }
    }

    public class Query : IQuery<SpotsViewModel> { }
}
