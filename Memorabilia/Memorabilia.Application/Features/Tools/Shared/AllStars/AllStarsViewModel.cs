using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public class AllStarsViewModel
{
    public AllStarsViewModel() { }

    public AllStarsViewModel(IEnumerable<AllStar> allStars, Domain.Constants.Sport sport)
    {
        AllStars = allStars.Select(allStar => new AllStarViewModel(allStar, sport))
                           .OrderBy(allStar => allStar.PersonName);
    }    

    public IEnumerable<AllStarViewModel> AllStars { get; set; } = Enumerable.Empty<AllStarViewModel>();

    public string ResultsTitle => $"{Year} All Stars";

    public int Year { get; set; }
}
