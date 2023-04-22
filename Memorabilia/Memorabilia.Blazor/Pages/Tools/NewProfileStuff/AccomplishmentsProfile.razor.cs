namespace Memorabilia.Blazor.Pages.Tools.NewProfileStuff;

public partial class AccomplishmentsProfile
{
    [Parameter]
    public Domain.Entities.Person Person { get; set; }

    [Parameter]
    public Sport Sport { get; set; }

    private AccomplishmentProfileViewModel[] Accomplishments = Array.Empty<AccomplishmentProfileViewModel>();

    protected override void OnParametersSet()
    {
        Accomplishments = Person.Accomplishments
                                .Filter(Sport)
                                .Select(accomplishment => new AccomplishmentProfileViewModel(accomplishment))
                                .ToArray();
    }
}
