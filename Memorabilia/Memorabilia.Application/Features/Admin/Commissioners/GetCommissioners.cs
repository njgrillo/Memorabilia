namespace Memorabilia.Application.Features.Admin.Commissioners;

public class GetCommissioners : ViewModel
{
    public class Handler : QueryHandler<Query, CommissionersViewModel>
    {
        private readonly ICommissionerRepository _commissionerRepository;

        public Handler(ICommissionerRepository commissionerRepository)
        {
            _commissionerRepository = commissionerRepository;
        }

        protected override async Task<CommissionersViewModel> Handle(Query query)
        {
            var commissioners = (await _commissionerRepository.GetAll(query.SportId))
                                            .OrderBy(commissioner => commissioner.SportLeagueLevelName)
                                            .ThenByDescending(commissioner => commissioner.BeginYear);

            return new CommissionersViewModel(commissioners);
        }
    }

    public class Query : IQuery<CommissionersViewModel>
    {
        public Query(int? sportId = null)
        {
            SportId = sportId;
        }

        public int? SportId { get; }
    }
}
