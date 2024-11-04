namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class AccomplishmentsProfile : PersonProfile
{
    [Parameter]
    public Sport Sport { get; set; }

    private AccomplishmentProfileModel[] Accomplishments 
        = [];

    private string _search;

    protected override void OnParametersSet()
    {
        Accomplishments = Person.Accomplishments
                                .Filter(Sport, OccupationType)
                                .Select(accomplishment => new AccomplishmentProfileModel(accomplishment))
                                .ToArray();
    }

    private bool Filter(AccomplishmentProfileModel model)
        => model.Filter(_search);
}
