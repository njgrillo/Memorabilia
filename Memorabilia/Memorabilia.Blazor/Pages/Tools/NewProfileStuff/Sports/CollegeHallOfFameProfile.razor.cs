using Memorabilia.Domain.Entities;

namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class CollegeHallOfFameProfile
{
    [Parameter]
    public Person Person { get; set; }

    private CollegeHallOfFame[] CollegeHallOfFames;

    protected override void OnParametersSet()
    {
        CollegeHallOfFames = Person.CollegeHallOfFames
                                   .OrderBy(college => college.College.Name)
                                   .ToArray();
    }
}
