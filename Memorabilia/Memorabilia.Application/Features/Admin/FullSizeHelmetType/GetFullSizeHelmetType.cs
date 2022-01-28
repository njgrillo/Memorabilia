using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.FullSizeHelmetType
{
    public class GetFullSizeHelmetType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IFullSizeHelmetTypeRepository _fullSizeHelmetTypeRepository;

            public Handler(IFullSizeHelmetTypeRepository fullSizeHelmetTypeRepository)
            {
                _fullSizeHelmetTypeRepository = fullSizeHelmetTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var fullSizeHelmetType = await _fullSizeHelmetTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(fullSizeHelmetType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id)
            {
            }
        }
    }
}
