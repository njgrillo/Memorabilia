﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public class AllStarsViewModel
{
    private readonly Domain.Constants.Sport _sport;

    public AllStarsViewModel() { }

    public AllStarsViewModel(IEnumerable<AllStar> allStars, Domain.Constants.Sport sport, int year)
    {
        _sport = sport;
        Year = year;

        var items = allStars.Select(allStar => new AllStarViewModel(allStar, sport))
                            .OrderBy(allStar => allStar.PersonName);

        if (!DisplayABAAllStars && !DisplayAFLProBowlers)
        {
            AllStars = items;
            return;
        }

        AllStars = _sport == Domain.Constants.Sport.Basketball
            ? items.Where(allStar => allStar.SportLeagueLevel == Domain.Constants.SportLeagueLevel.NationalBasketballAssociation)
                   .OrderBy(allStar => allStar.PersonName)
            : items.Where(allStar => allStar.SportLeagueLevel == Domain.Constants.SportLeagueLevel.NationalFootballLeague)
                   .OrderBy(allStar => allStar.PersonName);

        SecondaryAllStars = _sport == Domain.Constants.Sport.Basketball
            ? items.Where(allStar => allStar.SportLeagueLevel == Domain.Constants.SportLeagueLevel.AmericanBasketballAssociation)
                   .OrderBy(allStar => allStar.PersonName)
            : items.Where(allStar => allStar.SportLeagueLevel == Domain.Constants.SportLeagueLevel.AmericanFootballLeague)
                   .OrderBy(allStar => allStar.PersonName);
    }    

    public IEnumerable<AllStarViewModel> AllStars { get; set; } = Enumerable.Empty<AllStarViewModel>();

    public string CanceledMessage
        => IsBaseballCanceled 
        ? "2020 All Star Game canceled due to Covid-19."
        : "1999 All Star Game canceled due to work stoppage.";

    public bool DisplayABAAllStars
        => _sport == Domain.Constants.Sport.Basketball &&
           Year >= 1968 &&
           Year <= 1976;

    public bool DisplayAFLProBowlers
        => _sport == Domain.Constants.Sport.Football &&
           Year >= 1961 &&
           Year <= 1969;

    public bool DisplayCanceledMessage
        => IsBaseballCanceled || IsBasketballCanceled;

    public bool DisplayNoProBowlMessage
        => _sport == Domain.Constants.Sport.Football &&
           Year > 1942 &&
           Year < 1950;

    public bool IsBaseballCanceled
        => _sport == Domain.Constants.Sport.Baseball &&
           Year == 2020;

    public bool IsBasketballCanceled
        => _sport == Domain.Constants.Sport.Basketball &&
           Year == 1999;

    public bool IsDoubleHeaderAllStarGame
        => _sport == Domain.Constants.Sport.Baseball &&
           Year >= 1959 &&
           Year <= 1962;

    public string MainGridTitle
        => DisplayABAAllStars
           ? $"{Year} {Domain.Constants.SportLeagueLevel.NationalBasketballAssociation.Name} All Stars"
           : $"{Year} {(_sport == Domain.Constants.Sport.Football && Year > 1942 ? "Pro Bowlers" : "All Stars")}";

    public IEnumerable<AllStarViewModel> SecondaryAllStars { get; set; } 
        = Enumerable.Empty<AllStarViewModel>();

    public string SecondaryGridTitle
        => _sport == Domain.Constants.Sport.Basketball
        ? $"{Year} {Domain.Constants.SportLeagueLevel.AmericanBasketballAssociation.Name} All Stars"
        : $"{Year} {Domain.Constants.SportLeagueLevel.AmericanFootballLeague.Name} Pro Bowlers";

    public int Year { get; set; }
}
