using Memorabilia.Application.Services.Interfaces;
using Memorabilia.Application.Services.Tools.Profile;

namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class PersonProfileSelect
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IProfileService ProfileService { get; set; }

    public Entity.Person Model { get; set; }

    private void SelectedPersonChanged(Entity.Person person)
    {
        NavigationManager.NavigateTo($"{NavigationPath.PersonProfile}/{DataProtectorService.EncryptId(person.Id)}");
    }
}
