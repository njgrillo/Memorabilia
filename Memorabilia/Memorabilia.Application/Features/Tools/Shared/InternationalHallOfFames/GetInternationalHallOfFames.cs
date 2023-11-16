namespace Memorabilia.Application.Features.Tools.Shared.InternationalHallOfFames;

public record GetInternationalHallOfFames(int InternationalHallOfFameTypeId, 
                                          Constant.Sport Sport) 
    : IQuery<Entity.InternationalHallOfFame[]>
{
    public class Handler(IInternationalHallOfFameRepository internationalHallOfFameRepository) 
        : QueryHandler<GetInternationalHallOfFames, Entity.InternationalHallOfFame[]>
    {
        protected override async Task<Entity.InternationalHallOfFame[]> Handle(GetInternationalHallOfFames query)
            => (await internationalHallOfFameRepository.GetAll(query.InternationalHallOfFameTypeId, query.Sport.Id))
                    .ToArray();
    }
}
