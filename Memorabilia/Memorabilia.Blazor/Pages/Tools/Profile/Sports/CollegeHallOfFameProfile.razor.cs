namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class CollegeHallOfFameProfile : SportProfile
{
    private Entity.CollegeHallOfFame[] CollegeHallOfFames
        = [];

    protected override void OnParametersSet()
    {
        CollegeHallOfFames = Person.CollegeHallOfFames
                                   .OrderBy(college => college.College.Name)
                                   .ToArray();
    }

    private bool Filter(Entity.CollegeHallOfFame model)
        => model.Filter(Search);
}
