using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.InternationalHallOfFames;

public record GetInternationalHallOfFames(int InternationalHallOfFameTypeId, Sport Sport) 
    : IQuery<InternationalHallOfFamesModel>
{
    public class Handler : QueryHandler<GetInternationalHallOfFames, InternationalHallOfFamesModel>
    {
        private readonly IInternationalHallOfFameRepository _internationalHallOfFameRepository;

        public Handler(IInternationalHallOfFameRepository internationalHallOfFameRepository)
        {
            _internationalHallOfFameRepository = internationalHallOfFameRepository;
        }

        protected override async Task<InternationalHallOfFamesModel> Handle(GetInternationalHallOfFames query)
        {
            return new InternationalHallOfFamesModel(await _internationalHallOfFameRepository.GetAll(query.InternationalHallOfFameTypeId, query.Sport.Id), query.Sport)
            {
                InternationalHallOfFameTypeId = query.InternationalHallOfFameTypeId
            };
        }
    }
}
