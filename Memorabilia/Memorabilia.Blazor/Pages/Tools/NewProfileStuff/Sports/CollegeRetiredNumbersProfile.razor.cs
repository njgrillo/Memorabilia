namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class CollegeRetiredNumbersProfile : SportProfile
{
    private Domain.Entities.CollegeRetiredNumber[] CollegeRetiredNumbers;

    protected override void OnParametersSet()
    {
        CollegeRetiredNumbers = Person.CollegeRetiredNumbers
                                      .OrderBy(number => number.College.Name)
                                      .ToArray();
    }
}
