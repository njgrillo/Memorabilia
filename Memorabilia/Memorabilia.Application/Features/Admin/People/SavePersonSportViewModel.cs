using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonSportViewModel : SaveViewModel
{
    public SavePersonSportViewModel() { }

    public SavePersonSportViewModel(PersonSport sport)
    {
        Id = sport.Id;
        IsPrimary= sport.IsPrimary;
        PersonId = sport.PersonId;
        Sport = Domain.Constants.Sport.Find(sport.SportId);
    }

    public bool IsPrimary { get; set; } 

    public int PersonId { get; set; }

    public Domain.Constants.Sport Sport { get; set; }

    public string SportName => Sport?.Name;

    public string TypeName => IsPrimary ? "Primary" : "Secondary";
}
