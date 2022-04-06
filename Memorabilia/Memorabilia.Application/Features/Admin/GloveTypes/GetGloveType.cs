using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.GloveTypes
{
    public class GetGloveType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IGloveTypeRepository _gloveTypeRepository;

            public Handler(IGloveTypeRepository gloveTypeRepository)
            {
                _gloveTypeRepository = gloveTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _gloveTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
