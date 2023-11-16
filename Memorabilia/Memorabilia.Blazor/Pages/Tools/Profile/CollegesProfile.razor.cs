namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class CollegesProfile : PersonProfile
{
    private Entity.PersonCollege[] Colleges 
        = [];

    protected override void OnParametersSet()
    {
        Colleges = Person.Colleges
                         .OrderBy(college => college.BeginYear ?? 0)
                         .ToArray();
    }
}
