using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.RetiredNumbers;

public record GetRetiredNumbers(Franchise Franchise, Sport Sport) : IQuery<RetiredNumbersModel>
{
    public class Handler : QueryHandler<GetRetiredNumbers, RetiredNumbersModel>
    {
        private readonly IRetiredNumberRepository _retiredNumberRepository;

        public Handler(IRetiredNumberRepository retiredNumberRepository)
        {
            _retiredNumberRepository = retiredNumberRepository;
        }

        protected override async Task<RetiredNumbersModel> Handle(GetRetiredNumbers query)
        {
            return new RetiredNumbersModel(await _retiredNumberRepository.GetAll(query.Franchise.Id), query.Sport)
            {
                Franchise = query.Franchise
            };
        }
    }
}
