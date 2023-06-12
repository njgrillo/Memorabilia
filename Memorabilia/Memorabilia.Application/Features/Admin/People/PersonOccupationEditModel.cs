namespace Memorabilia.Application.Features.Admin.People;

public class PersonOccupationEditModel : EditModel
{
    public PersonOccupationEditModel() { }

    public PersonOccupationEditModel(Entity.PersonOccupation occupation)
    {
        Id = occupation.Id;
        Occupation = Constant.Occupation.Find(occupation.OccupationId);
        OccupationType = Constant.OccupationType.Find(occupation.OccupationTypeId);
    }

    public Constant.Occupation Occupation { get; set; }

    public string OccupationName 
        => Occupation?.Name;

    public Constant.OccupationType OccupationType { get; set; } 
        = Constant.OccupationType.Primary;

    public string OccupationTypeName 
        => OccupationType?.Name;
}
