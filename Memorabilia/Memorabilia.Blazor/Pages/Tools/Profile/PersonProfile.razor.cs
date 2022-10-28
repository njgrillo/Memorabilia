#nullable disable

namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class PersonProfile : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IProfileService ProfileService { get; set; }

    [Parameter]
    public PersonViewModel SelectedPerson { get; set; }

    public PersonViewModel ViewModel
    {
        get => SelectedPerson;
        set
        {
            SelectedPerson = value;
            SelectedPersonChanged(SelectedPerson);
        }
    }

    protected void OnLoad() { }

    private async Task SelectedPersonChanged(PersonViewModel person)
    {
        var profiles = await ProfileService.GetProfileTypes(person.Id);
        var profile = profiles.FirstOrDefault();

        NavigationManager.NavigateTo($"Tools/{profile.Name}Profile/{person.Id}");
    }
}
