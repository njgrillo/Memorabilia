namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonFranchiseHallOfFameApiModel
{
    private readonly Entity.FranchiseHallOfFame _franchiseHallOfFame;

    public PersonFranchiseHallOfFameApiModel(Entity.FranchiseHallOfFame franchiseHallOfFame)
    {
        _franchiseHallOfFame = franchiseHallOfFame;
    }

    public string Franchise
        => _franchiseHallOfFame.Franchise.FullName;

    public int? Year
        => _franchiseHallOfFame.Year;
}
