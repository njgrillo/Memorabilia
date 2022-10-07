using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Orientations;

public class GetOrientation
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<Orientation> _orientationRepository;

        public Handler(IDomainRepository<Orientation> orientationRepository)
        {
            _orientationRepository = orientationRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _orientationRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
