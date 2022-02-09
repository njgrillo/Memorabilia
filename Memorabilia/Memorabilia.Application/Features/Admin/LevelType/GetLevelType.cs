using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.LevelType
{
    public class GetLevelType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly ILevelTypeRepository _levelTypeRepository;

            public Handler(ILevelTypeRepository levelTypeRepository)
            {
                _levelTypeRepository = levelTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var levelType = await _levelTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(levelType);

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
