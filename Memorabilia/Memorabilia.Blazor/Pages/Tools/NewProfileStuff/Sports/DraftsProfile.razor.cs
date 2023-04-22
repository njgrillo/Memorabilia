namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff.Sports;

public partial class DraftsProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private Domain.Entities.Draft[] Drafts;

    protected override void OnParametersSet()
    {
        Drafts = Person.Drafts
                       .Filter(Sport)
                       .OrderBy(draft => draft.Year)
                       .ThenBy(draft => draft.Franchise.FullName)
                       .ToArray();
    }
}
