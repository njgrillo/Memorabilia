namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public record GetAllStars(int Year, Constant.Sport Sport) : IQuery<Entity.AllStar[]>
{
    public class Handler : QueryHandler<GetAllStars, Entity.AllStar[]>
    {
        private readonly IAllStarRepository _allStarRepository;

        public Handler(IAllStarRepository allStarRepository)
        {
            _allStarRepository = allStarRepository;
        }

        protected override async Task<Entity.AllStar[]> Handle(GetAllStars query)
            => (await _allStarRepository.GetAll(query.Year, query.Sport))
                    .ToArray();
    }
}
