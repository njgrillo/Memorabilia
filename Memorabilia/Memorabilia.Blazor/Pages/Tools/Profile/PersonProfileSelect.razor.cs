namespace Memorabilia.Blazor.Pages.Tools.Profile;

public partial class PersonProfileSelect
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IProfileService ProfileService { get; set; }

    public Entity.Person ViewModel { get; set; }

    private void SelectedPersonChanged(Entity.Person person)
    {
        NavigationManager.NavigateTo($"Tools/PersonProfile/{person.Id}");
    }
}
