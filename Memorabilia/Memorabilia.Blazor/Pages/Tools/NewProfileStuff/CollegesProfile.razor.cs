﻿namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public partial class CollegesProfile : PersonProfile
{
    private Domain.Entities.PersonCollege[] Colleges;

    protected override void OnParametersSet()
    {
        Colleges = Person.Colleges
                         .OrderBy(college => college.BeginYear ?? 0)
                         .ToArray();
    }
}
