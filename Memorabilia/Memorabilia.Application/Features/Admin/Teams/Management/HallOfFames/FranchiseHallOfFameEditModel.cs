namespace Memorabilia.Application.Features.Admin.Teams.Management.HallOfFames;

public class FranchiseHallOfFameEditModel : EditModel
{
    public FranchiseHallOfFameEditModel() { }

    public FranchiseHallOfFameEditModel(Entity.FranchiseHallOfFame hallOfFame)
    {
        FranchiseId = hallOfFame.FranchiseId;
        Id = hallOfFame.Id;
        Person = new PersonModel(hallOfFame.Person);
        Year = hallOfFame.Year;
    }

    public FranchiseHallOfFameEditModel(
        int personId,
        int franchiseId,
        int? year)
    {
        FranchiseId = franchiseId;
        PersonId = personId;
        Year = year;
    }

    public Constant.Franchise Franchise
        => Constant.Franchise.Find(FranchiseId);

    public int FranchiseId { get; set; }

    public string FranchiseName
        => Constant.Franchise.Find(FranchiseId)?.Name;

    public PersonModel Person { get; set; }
        = new();

    public int PersonId { get; set; }    

    public Guid? TemporaryId { get; set; }

    public int? Year { get; set; }

    public int GetPersonId()
    {
        return Person?.Id > 0 ? Person.Id : PersonId;
    }

    public bool Search(string search)
    {
        bool isNumber = int.TryParse(search, out var number);

        return search.IsNullOrEmpty() ||
               (isNumber && Year == number) ||
               Person.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.ProfileName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               Person.Nicknames.Any(x => x.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
