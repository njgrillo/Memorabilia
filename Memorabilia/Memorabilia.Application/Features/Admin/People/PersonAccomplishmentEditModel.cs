namespace Memorabilia.Application.Features.Admin.People;

public class PersonAccomplishmentEditModel : EditModel
{
    public PersonAccomplishmentEditModel() { }

    public PersonAccomplishmentEditModel(Entity.PersonAccomplishment accomplishment)
    {
        AccomplishmentType = Constant.AccomplishmentType.Find(accomplishment.AccomplishmentTypeId);
        Date = accomplishment.Date;
        Id = accomplishment.Id;
        PersonId = accomplishment.PersonId;
        Year = accomplishment.Year;
    }

    public Constant.AccomplishmentType AccomplishmentType { get; set; }

    public string AccomplishmentTypeName 
        => AccomplishmentType?.Name;

    public DateTime? Date { get; set; }

    public string FormattedDate 
        => Date?.ToString("MM/dd/yyyy");

    public int PersonId { get; set; }

    public int? Year { get; set; }
}
