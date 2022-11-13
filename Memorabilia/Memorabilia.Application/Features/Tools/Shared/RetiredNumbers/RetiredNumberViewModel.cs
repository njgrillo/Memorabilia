using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Tools.Shared.RetiredNumbers;

public class RetiredNumberViewModel : PersonSportToolViewModel
{
    private readonly RetiredNumber _retiredNumber;

    public RetiredNumberViewModel(RetiredNumber retiredNumber, Domain.Constants.SportLeagueLevel sportLeagueLevel)
    {
        _retiredNumber = retiredNumber;
        SportLeagueLevel = sportLeagueLevel;
    }

    public string FranchiseName => _retiredNumber.Franchise.FullName;   

    public override int PersonId => _retiredNumber.PersonId;

    public override string PersonImageFileName => _retiredNumber.Person.ImageFileName;

    public override string PersonName => _retiredNumber.Person.DisplayName;

    public int PlayerNumber => _retiredNumber.PlayerNumber;
}
