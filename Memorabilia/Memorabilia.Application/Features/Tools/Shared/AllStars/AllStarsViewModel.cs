using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public class AllStarsViewModel
{
    private Domain.Constants.Sport _sport;

    public AllStarsViewModel() { }

    public AllStarsViewModel(IEnumerable<AllStar> allStars, Domain.Constants.Sport sport)
    {
        _sport = sport;

        AllStars = allStars.Select(allStar => new AllStarViewModel(allStar, sport))
                           .OrderBy(allStar => allStar.PersonName);
    }    

    public IEnumerable<AllStarViewModel> AllStars { get; set; } = Enumerable.Empty<AllStarViewModel>();

    public string ResultsTitle 
        => $"{Year} {(_sport == Domain.Constants.Sport.Football ? "Pro Bowlers" : "All Stars")}";

    public int Year { get; set; }
}
