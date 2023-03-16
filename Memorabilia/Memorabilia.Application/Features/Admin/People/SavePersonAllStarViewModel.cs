using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonAllStarViewModel : SaveViewModel
{
    public SavePersonAllStarViewModel() { }

    public SavePersonAllStarViewModel(AllStar allStar)
    {
        Id = allStar.Id;
        PersonId = allStar.PersonId;
        Sport = Domain.Constants.Sport.Find(allStar.SportId);
        Year = allStar.Year;
    }

    public int PersonId { get; set; }

    public Domain.Constants.Sport Sport { get; set; }

    public string SportName => Sport?.Name;

    public int Year { get; set; }
}
