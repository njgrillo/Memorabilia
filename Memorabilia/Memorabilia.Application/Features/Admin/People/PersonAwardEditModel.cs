namespace Memorabilia.Application.Features.Admin.People;

public class PersonAwardEditModel : EditModel
{
    public PersonAwardEditModel() { }

    public PersonAwardEditModel(Constant.AwardType awardType, int year)
    {
        AwardType = awardType;
        Year = year;
    }

    public PersonAwardEditModel(Entity.PersonAward award)
    {
        AwardType = Constant.AwardType.Find(award.AwardTypeId);
        Id = award.Id;
        PersonId = award.PersonId;
        Year = award.Year;
    }

    public Constant.AwardType AwardType { get; set; }

    public string AwardTypeName 
        => AwardType?.Name;

    public int PersonId { get; set; }

    public int Year { get; set; }

    public bool Search(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
           AwardTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (isNumeric && Year == year);
    }
}
