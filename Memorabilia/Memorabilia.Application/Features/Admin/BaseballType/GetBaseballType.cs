using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BaseballType
{
    public class GetBaseballType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IBaseballTypeRepository _baseballTypeRepository;

            public Handler(IBaseballTypeRepository baseballTypeRepository)
            {
                _baseballTypeRepository = baseballTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var baseballType = await _baseballTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(baseballType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
