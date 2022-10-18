namespace Memorabilia.Application.Features.Admin.Commissioners;

public record GetCommissioner(int Id) : IQuery<CommissionerViewModel>
{
    public class Handler : QueryHandler<GetCommissioner, CommissionerViewModel>
    {
        private readonly ICommissionerRepository _commissionerRepository;

        public Handler(ICommissionerRepository commissionerRepository)
        {
            _commissionerRepository = commissionerRepository;
        }

        protected override async Task<CommissionerViewModel> Handle(GetCommissioner query)
        {
            return new CommissionerViewModel(await _commissionerRepository.Get(query.Id));
        }
    }
}
