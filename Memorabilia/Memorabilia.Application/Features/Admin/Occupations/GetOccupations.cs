using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Occupations;

public class GetOccupations
{
    public class Handler : QueryHandler<Query, OccupationsViewModel>
    {
        private readonly IDomainRepository<Occupation> _occupationRepository;

        public Handler(IDomainRepository<Occupation> occupationRepository)
        {
            _occupationRepository = occupationRepository;
        }

        protected override async Task<OccupationsViewModel> Handle(Query query)
        {
            return new OccupationsViewModel(await _occupationRepository.GetAll());
        }
    }

    public class Query : IQuery<OccupationsViewModel> { }
}
