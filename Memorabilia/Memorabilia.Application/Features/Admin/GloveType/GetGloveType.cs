using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.GloveType
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
                var gloveType = await _gloveTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(gloveType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
