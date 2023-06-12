namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class CollegeRetiredNumbersProfile : SportProfile
{
    private Entity.CollegeRetiredNumber[] CollegeRetiredNumbers
         = Array.Empty<Entity.CollegeRetiredNumber>();

    protected override void OnParametersSet()
    {
        CollegeRetiredNumbers = Person.CollegeRetiredNumbers
                                      .OrderBy(number => number.College.Name)
                                      .ToArray();
    }
}
