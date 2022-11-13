namespace Memorabilia.Application.Features.Tools.Shared.InternationalHallOfFames;

public record GetInternationalHallOfFames(int InternationalHallOfFameTypeId, Domain.Constants.SportLeagueLevel SportLeagueLevel) : IQuery<InternationalHallOfFamesViewModel>
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
            return new InternationalHallOfFamesViewModel(await _internationalHallOfFameRepository.GetAll(query.InternationalHallOfFameTypeId, query.SportLeagueLevel.Id), query.SportLeagueLevel)
            {
                InternationalHallOfFameTypeId = query.InternationalHallOfFameTypeId
            };
        }
    }
}
