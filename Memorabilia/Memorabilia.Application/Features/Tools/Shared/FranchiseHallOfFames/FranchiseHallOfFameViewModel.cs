using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;

public class FranchiseHallOfFameViewModel : PersonSportToolViewModel
{
    private readonly FranchiseHallOfFame _franchiseHallOfFame;

    public FranchiseHallOfFameViewModel(FranchiseHallOfFame franchiseHallOfFame, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        _franchiseHallOfFame = franchiseHallOfFame;
        SportLeagueLevel = sportLeagueLevel;
    }

    public string FranchiseName => _franchiseHallOfFame.Franchise.FullName;

    public string InductionYear => _franchiseHallOfFame.Year.ToString();

    public override int PersonId => _franchiseHallOfFame.PersonId;

    public override string PersonImageFileName => _franchiseHallOfFame.Person.ImageFileName;

    public override string PersonName => _franchiseHallOfFame.Person.DisplayName;
}
