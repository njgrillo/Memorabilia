namespace Memorabilia.Application.Features.Tools.Shared.Accomplishments;

public class AccomplishmentModel : PersonSportToolModel
{
    private readonly Entity.PersonAccomplishment _personAccomplishment;

    public AccomplishmentModel(Entity.PersonAccomplishment personAccomplishment, Constant.Sport sport)
    {
        _personAccomplishment = personAccomplishment;
        Sport = sport;
    }

    public string AccomplishmentTypeName 
        => Constant.AccomplishmentType.Find(_personAccomplishment.AccomplishmentTypeId)?.Name;

    public DateTime? Date 
        => _personAccomplishment.Date;

    public override int PersonId 
        => _personAccomplishment.PersonId;

    public override string PersonImageFileName 
        => _personAccomplishment.Person.ImageFileName;

    public override string PersonName
        => _personAccomplishment.Person.ProfileName;

    public int? Year 
        => _personAccomplishment?.Year ?? null;
}
