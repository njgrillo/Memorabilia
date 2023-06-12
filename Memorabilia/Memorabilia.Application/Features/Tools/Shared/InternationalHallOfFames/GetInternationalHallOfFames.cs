namespace Memorabilia.Application.Features.Tools.Shared.InternationalHallOfFames;

public record GetInternationalHallOfFames(int InternationalHallOfFameTypeId, 
                                          Constant.Sport Sport) 
    : IQuery<Entity.InternationalHallOfFame[]>
{
    public class Handler : QueryHandler<GetInternationalHallOfFames, Entity.InternationalHallOfFame[]>
    {
        private readonly IInternationalHallOfFameRepository _internationalHallOfFameRepository;

        public Handler(IInternationalHallOfFameRepository internationalHallOfFameRepository)
        {
            _internationalHallOfFameRepository = internationalHallOfFameRepository;
        }

        protected override async Task<Entity.InternationalHallOfFame[]> Handle(GetInternationalHallOfFames query)
            => (await _internationalHallOfFameRepository.GetAll(query.InternationalHallOfFameTypeId, query.Sport.Id))
                    .ToArray();
    }
}
