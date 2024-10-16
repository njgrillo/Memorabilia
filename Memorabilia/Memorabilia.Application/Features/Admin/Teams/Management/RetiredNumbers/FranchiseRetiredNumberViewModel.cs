namespace Memorabilia.Application.Features.Admin.Teams.Management.RetiredNumbers;

public class FranchiseRetiredNumberViewModel
{
    private readonly Entity.Franchise _franchise;

    public FranchiseRetiredNumberViewModel() { }

    public FranchiseRetiredNumberViewModel(Entity.Franchise franchise)
    {
        _franchise = franchise;
    }

    public int FranchiseId
        => _franchise.Id;

    public string FranchiseName
        => _franchise.Name;

    public int RetiredNumberCount
        => _franchise.RetiredNumbers.Count;

    public string SportLeagueLevelAbbreviation
        => _franchise.SportLeagueLevel.Abbreviation;
}
