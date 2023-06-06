namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public record GetAllStars(int Year, Constant.Sport Sport) : IQuery<AllStarsModel>
{
    public class Handler : QueryHandler<GetAllStars, AllStarsModel>
    {
        private readonly IAllStarRepository _allStarRepository;

        public Handler(IAllStarRepository allStarRepository)
        {
            _allStarRepository = allStarRepository;
        }

        protected override async Task<AllStarsModel> Handle(GetAllStars query)
        {
            return new AllStarsModel(await _allStarRepository.GetAll(query.Year, query.Sport), query.Sport, query.Year);
        }
    }
}
