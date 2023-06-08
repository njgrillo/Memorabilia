namespace Memorabilia.Application.Features.Tools.Shared.FranchiseHallOfFames;

public class FranchiseHallOfFameModel : PersonSportToolModel
{
    private readonly Entity.FranchiseHallOfFame _franchiseHallOfFame;

    public FranchiseHallOfFameModel(Entity.FranchiseHallOfFame franchiseHallOfFame, Constant.Sport sport)
    {
        _franchiseHallOfFame = franchiseHallOfFame;
        Sport = sport;
    }

    public string FranchiseName 
        => _franchiseHallOfFame.Franchise.FullName;

    public string InductionYear 
        => _franchiseHallOfFame.Year?.ToString() ?? string.Empty;

    public override int PersonId 
        => _franchiseHallOfFame.PersonId;

    public override string PersonImageFileName 
        => _franchiseHallOfFame.Person.ImageFileName;

    public override string PersonName
        => _franchiseHallOfFame.Person.DisplayName;
}
