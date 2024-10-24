namespace Memorabilia.Application.Features.Admin.People.Management.Accomplishments;

public class AccomplishmentEditModel : EditModel
{
    public AccomplishmentEditModel()
    {
        TemporaryId = Guid.NewGuid();
    }

    public AccomplishmentEditModel(Constant.AccomplishmentType accomplishmentType, DateTime? date, int personId, int? year)
    {
        AccomplishmentType = accomplishmentType;
        Date = date;
        PersonId = personId;
        Year = year;
    }

    public AccomplishmentEditModel(Entity.PersonAccomplishment personAccomplishment)
    {
        AccomplishmentType = Constant.AccomplishmentType.Find(personAccomplishment.AccomplishmentTypeId);
        Date = personAccomplishment.Date;
        Id = personAccomplishment.Id;
        PersonId = personAccomplishment.PersonId;
        Year = personAccomplishment.Year;
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

    public Guid? TemporaryId { get; set; }

    public int? Year { get; set; }

    public bool Search(string search)
    {
        bool isNumeric = int.TryParse(search, out int year);

        return search.IsNullOrEmpty() ||
           AccomplishmentTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (isNumeric && Year == year);
    }

    public void Set(int AccomplishmentTypeId, DateTime? date, int? year)
    {
        AccomplishmentType = Constant.AccomplishmentType.Find(AccomplishmentTypeId);
        Date = date;
        Year = year;
    }

    public void Set(int id, int AccomplishmentTypeId, DateTime? date, int? year)
    {
        AccomplishmentType = Constant.AccomplishmentType.Find(AccomplishmentTypeId);
        Date = date;
        Id = id;
        Year = year;
    }
}
