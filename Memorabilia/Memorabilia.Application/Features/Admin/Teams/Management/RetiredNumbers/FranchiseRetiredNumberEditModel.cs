namespace Memorabilia.Application.Features.Admin.Teams.Management.RetiredNumbers;

public class FranchiseRetiredNumberEditModel : EditModel
{
    public FranchiseRetiredNumberEditModel()
    {
        TemporaryId = Guid.NewGuid();
    }

    public FranchiseRetiredNumberEditModel(Entity.RetiredNumber retiredNumber)
    {
        FranchiseId = retiredNumber.FranchiseId;
        Id = retiredNumber.Id;
        Person = new PersonModel(retiredNumber.Person);
        PersonId = retiredNumber.PersonId;
        PlayerNumber = retiredNumber.PlayerNumber;
    }

    public FranchiseRetiredNumberEditModel(int id, int personId, string playerNumber)
    {
        Id = id;
        PersonId = personId;
        PlayerNumber = playerNumber;
    }

    public int FranchiseId { get; set; }

    public PersonModel Person { get; set; }
        = new();

    public int PersonId { get; set; }

    public string PlayerNumber { get; set; }

    public Guid? TemporaryId { get; set; }

    public int GetPersonId()
    {
        return Person?.Id > 0 ? Person.Id : PersonId;
    }

    public bool Search(string search)
    {
        return search.IsNullOrEmpty() ||
               Person.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.ProfileName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.Nicknames.Any(x => x.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase));
    }

    public void Set(int id, int personId, string playerNumber)
    {
        Id = id;
        PersonId = personId;
        PlayerNumber = playerNumber;
    }
}
