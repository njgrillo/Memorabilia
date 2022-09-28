namespace Memorabilia.Application.Features.Admin.Conditions
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
                return new ConditionsViewModel(await _conditionRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<ConditionsViewModel> { }
    }
}
