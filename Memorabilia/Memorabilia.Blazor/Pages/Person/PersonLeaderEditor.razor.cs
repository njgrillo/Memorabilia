namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonLeaderEditor
{
    [Parameter]
    public List<PersonLeaderEditModel> Leaders { get; set; } 
        = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonLeaderEditModel Model 
        = new();

    private string _years;

    private void Add()
    {
        if (Model.LeaderType == null)
            return;

        foreach (int year in _years.ToIntArray())
        {
            Leaders.Add(new PersonLeaderEditModel() { LeaderType = Model.LeaderType, Year = year });
        }

        Model = new();

        _years = string.Empty;
    }
}
