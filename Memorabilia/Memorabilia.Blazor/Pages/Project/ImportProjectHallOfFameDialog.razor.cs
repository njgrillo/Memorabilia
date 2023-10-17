namespace Memorabilia.Blazor.Pages.Project;

public partial class ImportProjectHallOfFameDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int SportLeagueLevelId { get; set; }

    [Parameter]
    public int? Year { get; set; }

    protected int MaxYear
        => DateTime.UtcNow.Year;

    protected Entity.Person[] People { get; set; } 
        = Array.Empty<Entity.Person>();     

    private bool Filter(Entity.Person person)
        => PersonFilterService.Filter(person, _search);

    private string _search;

    private string SelectAllButtonText
        => People != null && People.Length == SelectedPeople.Count
            ? "Deselect All"
            : "Select All";

    private List<Entity.Person> SelectedPeople 
        = new();

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    public void Import()
    {
        MudDialog.Close(DialogResult.Ok(SelectedPeople.ToArray()));
    }

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }

    protected void OnSelectAll()
    {
        SelectedPeople = People.Length == SelectedPeople.Count
            ? new()
            : People.ToList();
    }

    protected void PersonSelected(Entity.Person person)
    {
        if (!SelectedPeople.Contains(person))
        {
            SelectedPeople.Add(person);
            return;
        }

        SelectedPeople.Remove(person);
    }

    protected async Task Search()
    {
        People = (await Mediator.Send(new GetImportProjectHallOfFamePersons(SportLeagueLevelId, Year)))
                     .DistinctBy(person => person.Id)
                     .ToArray();
    }
}
