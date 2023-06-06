using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonAllStarViewModel : EditModel
{
    public SavePersonAllStarViewModel() { }

    public SavePersonAllStarViewModel(AllStar allStar)
    {
        Id = allStar.Id;
        PersonId = allStar.PersonId;
        Sport = Constant.Sport.Find(allStar.SportId);
        SportLeagueLevelId = allStar.SportLeagueLevelId.HasValue ? allStar.SportLeagueLevelId.Value : 0;
        Year = allStar.Year;
    }

    public int PersonId { get; set; }

    public Constant.Sport Sport { get; set; }

    public int SportLeagueLevelId { get; set; }

    public string SportLeagueLevelName => Constant.SportLeagueLevel.Find(SportLeagueLevelId)?.Name;

    public string SportName => Sport?.Name;

    public int Year { get; set; }
}
