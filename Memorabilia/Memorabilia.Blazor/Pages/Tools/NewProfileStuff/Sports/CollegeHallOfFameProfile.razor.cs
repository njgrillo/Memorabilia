using Memorabilia.Domain.Entities;

namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class CollegeHallOfFameProfile : SportProfile
{
    private CollegeHallOfFame[] CollegeHallOfFames;

    protected override void OnParametersSet()
    {
        CollegeHallOfFames = Person.CollegeHallOfFames
                                   .OrderBy(college => college.College.Name)
                                   .ToArray();
    }
}
