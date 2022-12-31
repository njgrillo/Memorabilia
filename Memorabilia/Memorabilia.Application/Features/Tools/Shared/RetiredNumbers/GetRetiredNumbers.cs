using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.RetiredNumbers;

public record GetRetiredNumbers(Franchise Franchise, Sport Sport) : IQuery<RetiredNumbersViewModel>
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
            return new RetiredNumbersViewModel(await _retiredNumberRepository.GetAll(query.Franchise.Id), query.Sport)
            {
                Franchise = query.Franchise
            };
        }
    }
}
