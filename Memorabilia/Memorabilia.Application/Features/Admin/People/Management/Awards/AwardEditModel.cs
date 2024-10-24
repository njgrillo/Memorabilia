namespace Memorabilia.Application.Features.Admin.People.Management.Awards;

public class AwardEditModel : EditModel
{
    public AwardEditModel()
    {
        TemporaryId = Guid.NewGuid();
    }

    public AwardEditModel(Constant.AwardType awardType, int personId, int year)
    {
        AwardType = awardType;
        PersonId = personId;
        Year = year;
    }

    public AwardEditModel(Entity.PersonAward personAward)
    {
        AwardType = Constant.AwardType.Find(personAward.AwardTypeId);
        Id = personAward.Id;
        PersonId = personAward.PersonId;
        Year = personAward.Year;
    }

    public Constant.AwardType AwardType { get; set; }

    public string AwardTypeName
        => AwardType?.Name;

    public int PersonId { get; set; }

    public Guid? TemporaryId { get; set; }

    public int? Year { get; set; }

    public void Set(int awardTypeId, int year)
    {
        AwardType = Constant.AwardType.Find(awardTypeId);
        Year = year;
    }

    public void Set(int id, int awardTypeId, int year)
    {
        AwardType = Constant.AwardType.Find(awardTypeId);
        Id = id;
        Year = year;
    }
}
