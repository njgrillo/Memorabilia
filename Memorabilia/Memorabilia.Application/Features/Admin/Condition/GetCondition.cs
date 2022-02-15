using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Condition
{
    public class GetCondition
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IConditionRepository _conditionRepository;

            public Handler(IConditionRepository conditionRepository)
            {
                _conditionRepository = conditionRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var condition = await _conditionRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(condition);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
