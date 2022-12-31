using Memorabilia.Domain.Entities;

namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class PersonProfile : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IProfileService ProfileService { get; set; }

    public Person ViewModel { get; set; }

    private async Task SelectedPersonChanged(Person person)
    {
        var profiles = await ProfileService.GetProfileTypes(person.Id);
        var profile = profiles.FirstOrDefault();

        NavigationManager.NavigateTo($"Tools/{profile.Name}Profile/{person.Id}");
    }
}
