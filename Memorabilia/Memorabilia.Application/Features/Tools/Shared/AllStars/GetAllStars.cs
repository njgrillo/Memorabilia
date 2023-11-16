namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public record GetAllStars(int Year, Constant.Sport Sport) : IQuery<Entity.AllStar[]>
{
    public class Handler(IAllStarRepository allStarRepository) 
        : QueryHandler<GetAllStars, Entity.AllStar[]>
    {
        protected override async Task<Entity.AllStar[]> Handle(GetAllStars query)
            => (await allStarRepository.GetAll(query.Year, query.Sport))
                    .ToArray();
    }
}
