using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.HelmetType
{
    public class GetHelmetType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IHelmetTypeRepository _helmetTypeRepository;

            public Handler(IHelmetTypeRepository helmetTypeRepository)
            {
                _helmetTypeRepository = helmetTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var helmetType = await _helmetTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(helmetType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
