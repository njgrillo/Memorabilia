namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class ImportProjectPersonTeamDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

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
        = Array.Empty<Entity.Person>();

    protected Entity.Team Team { get; set; }

    private bool FilterFunc1(Entity.Person person)
        => FilterFunc(person, _search);

    private string _search;

    private string SelectAllButtonText
        => People != null && People.Length == SelectedPeople.Count
            ? "Deselect All"
            : "Select All";

    private List<Entity.Person> SelectedPeople = new();

    protected override async Task OnInitializedAsync()
    {
        if (TeamId == 0)
            return;

        Team = await QueryRouter.Send(new GetTeam(TeamId));
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }

    protected static bool FilterFunc(Entity.Person person, string search)
        => search.IsNullOrEmpty() ||
           person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           person.ProfileName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           person.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           person.LastName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           person.LegalName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           person.Nicknames.Any(nickname => nickname.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.LegalName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.DisplayName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.ProfileName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.FirstName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1 ||
           CultureInfo.CurrentCulture.CompareInfo.IndexOf(person.LastName,
                                                          search,
                                                          CompareOptions.IgnoreNonSpace) > -1;    

    public void Import()
    {
        MudDialog.Close(DialogResult.Ok(SelectedPeople.ToArray()));
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
        People = (await QueryRouter.Send(new GetImportProjectTeamPersons(Team.Id, Year ?? 0)))
                     .DistinctBy(person => person.Id)
                     .ToArray();
    }
}
