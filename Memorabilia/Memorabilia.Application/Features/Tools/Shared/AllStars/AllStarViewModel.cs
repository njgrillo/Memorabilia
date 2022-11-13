using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.AllStars;

public class AllStarViewModel : PersonSportToolViewModel
{
    private readonly AllStar _allstar;

    public AllStarViewModel(AllStar allstar, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        _allstar = allstar;
        SportLeagueLevel = sportLeagueLevel;
    }

    public override int PersonId => _allstar.PersonId;

    public override string PersonImageFileName => _allstar.Person.ImageFileName;

    public override string PersonName => _allstar.Person.DisplayName;

    public string Year => _allstar.Year.ToString();
}
