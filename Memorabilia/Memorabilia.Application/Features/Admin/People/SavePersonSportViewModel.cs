using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonSportViewModel : SaveViewModel
{
    public SavePersonSportViewModel() { }

    public SavePersonSportViewModel(PersonSport sport)
    {
        Id = sport.Id;
        PersonId = sport.PersonId;
        Sport = Domain.Constants.Sport.Find(sport.SportId);
    }

    public int PersonId { get; set; }

    public Domain.Constants.Sport Sport { get; set; }

    public string SportName => Sport?.Name;
}
