using Demo.Framework.Handler;
using Memorabilia.Domain;

namespace Memorabilia.Application.Features.Admin.Condition
{
    public class GetCondition
    {
        public class Handler : QueryHandler<DomainQuery, DomainViewModel>
        {
            private readonly IConditionRepository _conditionRepository;

            public Handler(IConditionRepository conditionRepository)
            {
                _conditionRepository = conditionRepository;
            }

            protected override async Task<DomainViewModel> Handle(DomainQuery query)
            {
                var condition = await _conditionRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(condition);

                return viewModel;
            }
        }
    }
}
