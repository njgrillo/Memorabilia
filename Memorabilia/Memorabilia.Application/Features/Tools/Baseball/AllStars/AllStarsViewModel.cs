using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Baseball.AllStars;

public class AllStarsViewModel
{
    public AllStarsViewModel() { }

    public AllStarsViewModel(IEnumerable<AllStar> allStars)
    {
        AllStars = allStars.Select(allStar => new AllStarViewModel(allStar))
                           .OrderBy(allStar => allStar.PersonName);
    }    

    public IEnumerable<AllStarViewModel> AllStars { get; set; } = Enumerable.Empty<AllStarViewModel>();

    public string ResultsTitle => $"{Year} All Stars";

    public int Year { get; set; }
}
