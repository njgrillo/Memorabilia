namespace Memorabilia.Application.Features.Tools.Shared.Awards;

public record GetAwards(Constant.AwardType AwardType, Constant.Sport Sport) 
    : IQuery<Entity.PersonAward[]>
{
    public class Handler(IPersonAwardRepository personAwardRepository) 
        : QueryHandler<GetAwards, Entity.PersonAward[]>
    {
        protected override async Task<Entity.PersonAward[]> Handle(GetAwards query)
            => (await personAwardRepository.GetAll(query.AwardType.Id))
                    .ToArray();
    }
}
