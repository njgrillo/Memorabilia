using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.GloveTypes;

public class GetGloveType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<GloveType> _gloveTypeRepository;

        public Handler(IDomainRepository<GloveType> gloveTypeRepository)
        {
            _gloveTypeRepository = gloveTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _gloveTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
