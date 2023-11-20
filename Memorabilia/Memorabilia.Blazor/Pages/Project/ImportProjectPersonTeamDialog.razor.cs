namespace Memorabilia.Blazor.Pages.Project;

public partial class ImportProjectPersonTeamDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int TeamId { get; set; }

    [Parameter]
    public int? Year { get; set; } 
        = DateTime.UtcNow.Year;

    protected int MaxYear
        => DateTime.UtcNow.Year;

    protected Entity.Person[] People { get; set; } 
        = [];

    protected Entity.Team Team { get; set; }

    private bool FilterFunc(Entity.Person person)
        => PersonFilterService.Filter(person, _search);

    private string _search;

    private string SelectAllButtonText
        => People != null && People.Length == SelectedPeople.Count
            ? "Deselect All"
            : "Select All";

    private List<Entity.Person> SelectedPeople 
        = [];

    protected override async Task OnInitializedAsync()
    {
        if (TeamId == 0)
            return;

        Team = await Mediator.Send(new GetTeam(TeamId));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }   

    public void Import()
    {
        MudDialog.Close(DialogResult.Ok(SelectedPeople.ToArray()));
    }


    protected void OnSelectAll()
    {
        SelectedPeople = People.Length == SelectedPeople.Count
            ? []
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
        People = (await Mediator.Send(new GetImportProjectTeamPersons(Team.Id, Year ?? 0)))
                     .DistinctBy(person => person.Id)
                     .ToArray();
    }
}
