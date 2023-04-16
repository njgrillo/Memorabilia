﻿using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public class AllStarsViewModel
{
    private readonly Domain.Constants.Sport _sport;

    public AllStarsViewModel() { }

    public AllStarsViewModel(IEnumerable<AllStar> allStars, Domain.Constants.Sport sport)
    {
        _sport = sport;

        AllStars = allStars.Select(allStar => new AllStarViewModel(allStar, sport))
                           .OrderBy(allStar => allStar.PersonName);
    }    

    public IEnumerable<AllStarViewModel> AllStars { get; set; } = Enumerable.Empty<AllStarViewModel>();

    public bool DisplayCanceledMessage
        => _sport == Domain.Constants.Sport.Baseball &&
           Year == 2020;

    public bool IsDoubleHeaderAllStarGame
        => _sport == Domain.Constants.Sport.Baseball &&
           Year >= 1959 &&
           Year <= 1962;

    public string ResultsTitle 
        => $"{Year} {(_sport == Domain.Constants.Sport.Football ? "Pro Bowlers" : "All Stars")}";

    public int Year { get; set; }
}
