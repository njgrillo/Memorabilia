namespace Memorabilia.Application.Features.Tools.Baseball.RetiredNumbers;

public record GetRetiredNumbers(int FranchiseId) : IQuery<RetiredNumbersViewModel>
{
    public class Handler : QueryHandler<GetRetiredNumbers, RetiredNumbersViewModel>
    {
        private readonly IRetiredNumberRepository _retiredNumberRepository;

        public Handler(IRetiredNumberRepository retiredNumberRepository)
        {
            _retiredNumberRepository = retiredNumberRepository;
        }

        protected override async Task<RetiredNumbersViewModel> Handle(GetRetiredNumbers query)
        {
            return new RetiredNumbersViewModel(await _retiredNumberRepository.GetAll(query.FranchiseId))
            {
                FranchiseId = query.FranchiseId
            };
        }
    }
}
