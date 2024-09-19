namespace Memorabilia.Application.Features.Admin.People;

public class PersonAccomplishmentEditModel : EditModel
{
    public PersonAccomplishmentEditModel() { }

    public PersonAccomplishmentEditModel(Constant.AccomplishmentType accomplishmentType, DateTime? date = null, int? year = null)
    {
        AccomplishmentType = accomplishmentType;
        Date = date;
        Year = year;
    }

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

    public bool IsDateAccomplishment
        => AccomplishmentType?.IsDateAccomplishment() ?? false;

    public bool IsYearAccomplishment
        => (AccomplishmentType?.IsYearRangeAccomplishment() ?? false) || (AccomplishmentType?.IsYearAccomplishment() ?? false);

    public int PersonId { get; set; }

    public int? Year { get; set; }

    public bool Search(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
           AccomplishmentTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (isNumeric && Year == year);
    }
}
