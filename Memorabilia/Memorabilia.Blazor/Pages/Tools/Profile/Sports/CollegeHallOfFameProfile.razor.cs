namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class CollegeHallOfFameProfile : SportProfile
{
    private Entity.CollegeHallOfFame[] CollegeHallOfFames
        = Array.Empty<Entity.CollegeHallOfFame>();

    protected override void OnParametersSet()
    {
        CollegeHallOfFames = Person.CollegeHallOfFames
                                   .OrderBy(college => college.College.Name)
                                   .ToArray();
    }
}
