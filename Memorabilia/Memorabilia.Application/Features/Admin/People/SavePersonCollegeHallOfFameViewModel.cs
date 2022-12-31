using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.People;

public class SavePersonCollegeHallOfFameViewModel : SaveViewModel
{
    public SavePersonCollegeHallOfFameViewModel() { }

    public SavePersonCollegeHallOfFameViewModel(CollegeHallOfFame hof)
    {
        College = Domain.Constants.College.Find(hof.CollegeId);
        Id = hof.Id;
        PersonId = hof.PersonId;
        Sport = Domain.Constants.Sport.Find(hof.SportId);
        Year = hof.Year;
    }

    public Domain.Constants.College College { get; set; }

    public string CollegeName => College?.Name;

    public int PersonId { get; set; }

    public Domain.Constants.Sport Sport { get; set; }

    public string SportName => Sport?.Name;

    public int? Year { get; set; }
}
