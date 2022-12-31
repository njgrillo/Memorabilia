using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.InternationalHallOfFames;

public record GetInternationalHallOfFames(int InternationalHallOfFameTypeId, Sport Sport) 
    : IQuery<InternationalHallOfFamesViewModel>
{
    public class Handler : QueryHandler<GetInternationalHallOfFames, InternationalHallOfFamesViewModel>
    {
        private readonly IInternationalHallOfFameRepository _internationalHallOfFameRepository;

        public Handler(IInternationalHallOfFameRepository internationalHallOfFameRepository)
        {
            _internationalHallOfFameRepository = internationalHallOfFameRepository;
        }

        protected override async Task<InternationalHallOfFamesViewModel> Handle(GetInternationalHallOfFames query)
        {
            return new InternationalHallOfFamesViewModel(await _internationalHallOfFameRepository.GetAll(query.InternationalHallOfFameTypeId, query.Sport.Id), query.Sport)
            {
                InternationalHallOfFameTypeId = query.InternationalHallOfFameTypeId
            };
        }
    }
}
