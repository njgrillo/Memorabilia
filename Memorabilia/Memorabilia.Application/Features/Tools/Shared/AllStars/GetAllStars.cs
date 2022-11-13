namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public record GetAllStars(int Year, Domain.Constants.SportLeagueLevel SportLeagueLevel) : IQuery<AllStarsViewModel>
{
    public class Handler : QueryHandler<GetAllStars, AllStarsViewModel>
    {
        private readonly IAllStarRepository _allStarRepository;

        public Handler(IAllStarRepository allStarRepository)
        {
            _allStarRepository = allStarRepository;
        }

        protected override async Task<AllStarsViewModel> Handle(GetAllStars query)
        {
            return new AllStarsViewModel(await _allStarRepository.GetAll(query.Year), query.SportLeagueLevel)
            {
                Year = query.Year
            };
        }
    }
}
