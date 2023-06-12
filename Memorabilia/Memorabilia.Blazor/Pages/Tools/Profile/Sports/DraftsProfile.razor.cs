namespace Memorabilia.Blazor.Pages.Tools.Profile.Sports;

public partial class DraftsProfile : SportProfile
{
    private Entity.Draft[] Drafts;

    protected override void OnParametersSet()
    {
        Drafts = Person.Drafts
                       .Filter(Sport)
                       .OrderBy(draft => draft.Year)
                       .ThenBy(draft => draft.Franchise.FullName)
                       .ToArray();
    }
}
