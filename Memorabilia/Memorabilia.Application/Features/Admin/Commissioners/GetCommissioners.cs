namespace Memorabilia.Application.Features.Admin.Commissioners;

public record GetCommissioners(int? SportId = null) : IQuery<CommissionersViewModel>
{
    public class Handler : QueryHandler<GetCommissioners, CommissionersViewModel>
    {
        private readonly ICommissionerRepository _commissionerRepository;

        public Handler(ICommissionerRepository commissionerRepository)
        {
            _commissionerRepository = commissionerRepository;
        }

        protected override async Task<CommissionersViewModel> Handle(GetCommissioners query)
        {
            return new CommissionersViewModel(await _commissionerRepository.GetAll(query.SportId));
        }
    }
}
