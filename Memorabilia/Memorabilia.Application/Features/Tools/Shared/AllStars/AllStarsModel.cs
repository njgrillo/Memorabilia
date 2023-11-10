namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public class AllStarsModel
{
    private readonly Constant.Sport _sport;

    public AllStarsModel() { }

    public AllStarsModel(IEnumerable<Entity.AllStar> allStars, Constant.Sport sport, int year)
    {
        _sport = sport;
        Year = year;

        IOrderedEnumerable<AllStarModel> items = allStars.Select(allStar => new AllStarModel(allStar, sport))
                                                         .OrderBy(allStar => allStar.PersonName);

        if (!DisplayABAAllStars && !DisplayAFLProBowlers)
        {
            AllStars = items;
            return;
        }

        AllStars = _sport == Constant.Sport.Basketball
            ? items.Where(allStar => allStar.SportLeagueLevel == Constant.SportLeagueLevel.NationalBasketballAssociation)
                   .OrderBy(allStar => allStar.PersonName)
            : items.Where(allStar => allStar.SportLeagueLevel == Constant.SportLeagueLevel.NationalFootballLeague)
                   .OrderBy(allStar => allStar.PersonName);

        SecondaryAllStars = _sport == Constant.Sport.Basketball
            ? items.Where(allStar => allStar.SportLeagueLevel == Constant.SportLeagueLevel.AmericanBasketballAssociation)
                   .OrderBy(allStar => allStar.PersonName)
            : items.Where(allStar => allStar.SportLeagueLevel == Constant.SportLeagueLevel.AmericanFootballLeague)
                   .OrderBy(allStar => allStar.PersonName);
    }    

    public IEnumerable<AllStarModel> AllStars { get; set; } 
        = Enumerable.Empty<AllStarModel>();

    public string CanceledMessage
        => IsBaseballCanceled 
        ? "2020 All Star Game canceled due to Covid-19."
        : "1999 All Star Game canceled due to work stoppage.";

    public bool DisplayABAAllStars
        => _sport == Constant.Sport.Basketball &&
           Year >= 1968 &&
           Year <= 1976;

    public bool DisplayAFLProBowlers
        => _sport == Constant.Sport.Football &&
           Year >= 1961 &&
           Year <= 1969;

    public bool DisplayCanceledMessage
        => IsBaseballCanceled || IsBasketballCanceled;

    public bool DisplayNoProBowlMessage
        => _sport == Constant.Sport.Football &&
           Year > 1942 &&
           Year < 1950;

    public bool IsBaseballCanceled
        => _sport == Constant.Sport.Baseball &&
           Year == 2020;

    public bool IsBasketballCanceled
        => _sport == Constant.Sport.Basketball &&
           Year == 1999;

    public bool IsDoubleHeaderAllStarGame
        => _sport == Constant.Sport.Baseball &&
           Year >= 1959 &&
           Year <= 1962;

    public string MainGridTitle
        => DisplayABAAllStars
           ? $"{Year} {Constant.SportLeagueLevel.NationalBasketballAssociation.Name} All Stars"
           : $"{Year} {(_sport == Constant.Sport.Football && Year > 1942 ? "Pro Bowlers" : "All Stars")}";

    public IEnumerable<AllStarModel> SecondaryAllStars { get; set; } 
        = Enumerable.Empty<AllStarModel>();

    public string SecondaryGridTitle
        => _sport == Constant.Sport.Basketball
        ? $"{Year} {Constant.SportLeagueLevel.AmericanBasketballAssociation.Name} All Stars"
        : $"{Year} {Constant.SportLeagueLevel.AmericanFootballLeague.Name} All Stars";

    public string Title
        => _sport == Constant.Sport.Football
            ? "Pro Bowls"
            : "All Stars";

    public int Year { get; set; }
}
