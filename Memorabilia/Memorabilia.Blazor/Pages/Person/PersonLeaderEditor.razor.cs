namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonLeaderEditor
{
    [Parameter]
    public List<PersonLeaderEditModel> Leaders { get; set; } 
        = [];

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonLeaderEditModel Model 
        = new();

    private string _search;

    private string _years;

    private void Add()
    {
        if (Model.LeaderType == null)
            return;

        Leaders.AddRange(_years.ToIntArray().Select(year => new PersonLeaderEditModel(Model.LeaderType, year)));

        Model = new();

        _years = string.Empty;
    }

    private bool Filter(PersonLeaderEditModel personLeader)
        => personLeader.Search(_search);
}
