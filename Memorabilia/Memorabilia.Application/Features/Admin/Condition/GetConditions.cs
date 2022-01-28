using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Condition
{
    public class GetConditions
    {
        public class Handler : QueryHandler<Query, ConditionsViewModel>
        {
            private readonly IConditionRepository _conditionRepository;

            public Handler(IConditionRepository conditionRepository)
            {
                _conditionRepository = conditionRepository;
            }

            protected override async Task<ConditionsViewModel> Handle(Query query)
            {
                var conditions = await _conditionRepository.GetAll().ConfigureAwait(false);

                var viewModel = new ConditionsViewModel(conditions);

                return viewModel;
            }
        }

        public class Query : IQuery<ConditionsViewModel>
        {
        }
    }
}
