namespace Memorabilia.MinimalAPI.Models.Admin.People;

public class PersonFranchiseRetiredNumberApiModel
{
    private readonly Entity.RetiredNumber _franchiseRetiredNumber;

    public PersonFranchiseRetiredNumberApiModel(Entity.RetiredNumber franchiseRetiredNumber)
    {
        _franchiseRetiredNumber = franchiseRetiredNumber;
    }

    public string Name
        => Constant.Franchise.Find(_franchiseRetiredNumber.FranchiseId).Name;

    public string Number
        => _franchiseRetiredNumber.PlayerNumber.ToString();
}
