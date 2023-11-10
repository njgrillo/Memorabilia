namespace Memorabilia.Application.Features.Tools.Shared.RetiredNumbers;

public class RetiredNumberModel : PersonSportToolModel
{
    private readonly Entity.RetiredNumber _retiredNumber;

    public RetiredNumberModel(Entity.RetiredNumber retiredNumber, Constant.Sport sport)
    {
        _retiredNumber = retiredNumber;
        Sport = sport;
    }

    public string FranchiseName 
        => _retiredNumber.Franchise.FullName;   

    public override int PersonId 
        => _retiredNumber.PersonId;

    public override string PersonImageFileName 
        => _retiredNumber.Person.ImageFileName;

    public override string PersonName 
        => _retiredNumber.Person.ProfileName;

    public int PlayerNumber 
        => _retiredNumber.PlayerNumber;
}
