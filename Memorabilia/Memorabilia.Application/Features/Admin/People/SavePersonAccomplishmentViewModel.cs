using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonAccomplishmentViewModel : SaveViewModel
{
    public SavePersonAccomplishmentViewModel() { }

    public SavePersonAccomplishmentViewModel(PersonAccomplishment accomplishment)
    {
        AccomplishmentTypeId = accomplishment.AccomplishmentTypeId;
        Date = accomplishment.Date;
        Id = accomplishment.Id;
        PersonId = accomplishment.PersonId;
        Year = accomplishment.Year;
    }

    public int AccomplishmentTypeId { get; set; }

    public string AccomplishmentTypeName => Domain.Constants.AccomplishmentType.Find(AccomplishmentTypeId)?.Name;

    public DateTime? Date { get; set; }

    public string FormattedDate => Date?.ToString("MM/dd/yyyy");

    public int PersonId { get; set; }

    public int? Year { get; set; }
}
