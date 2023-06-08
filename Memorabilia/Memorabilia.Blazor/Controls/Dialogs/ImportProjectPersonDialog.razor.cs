namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class ImportProjectPersonDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int BaseballTypeId { get; set; }

    [Parameter]
    public int? Year { get; set; }

    protected int? BeginYear;
    protected int? EndYear;

    protected BaseballType BaseballType
        => BaseballType.Find(BaseballTypeId);

    protected bool CanImportByYearRange
        => BaseballType?.CanImportByYearRange() ?? false;

    private bool FilterFunc1(Entity.Person person)
        => FilterFunc(person, _search);

    protected int MaxYear
        => DateTime.UtcNow.Year;

    protected Entity.Person[] People { get; set; } 
        = Array.Empty<Entity.Person>();

    private string _search;

    private string SelectAllButtonText
        => People != null && People.Length == SelectedPeople.Count
            ? "Deselect All"
            : "Select All";
    
    private List<Entity.Person> SelectedPeople = new(); 

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
        var parameters = new Dictionary<string, object>();
        var baseballType = BaseballType.Find(BaseballTypeId);

        if (baseballType == BaseballType.GoldWorldSeries || baseballType == BaseballType.WorldSeries)
            parameters.Add("IsWorldSeries", true);

        if (baseballType == BaseballType.AllStar)
        {
            parameters.Add("IsAllStar", true);
            parameters.Add("SportId", Sport.Baseball.Id);
        }            

        if (baseballType == BaseballType.GoldGlove)
            parameters.Add("AwardTypeId", AwardType.GoldGlove.Id);

        parameters.Add("BeginYear", Year ?? BeginYear);

        if (EndYear.HasValue)
            parameters.Add("EndYear", EndYear.Value);

        People = (await QueryRouter.Send(new GetImportProjectPersons(parameters))).DistinctBy(person => person.Id)
                                                                                  .ToArray();
    }
}
