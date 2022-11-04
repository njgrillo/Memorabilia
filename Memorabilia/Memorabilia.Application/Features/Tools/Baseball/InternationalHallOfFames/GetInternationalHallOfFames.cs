namespace Memorabilia.Application.Features.Tools.Baseball.InternationalHallOfFames;

public record GetInternationalHallOfFames(int InternationalHallOfFameTypeId, int SportLeagueLevelId) : IQuery<InternationalHallOfFamesViewModel>
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
            return new InternationalHallOfFamesViewModel(await _internationalHallOfFameRepository.GetAll(query.InternationalHallOfFameTypeId, query.SportLeagueLevelId))
            {
                InternationalHallOfFameTypeId = query.InternationalHallOfFameTypeId
            };
        }
    }
}
