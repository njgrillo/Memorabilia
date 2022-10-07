using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Sizes;

public class GetSize
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<Size> _sizeRepository;

        public Handler(IDomainRepository<Size> sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _sizeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
