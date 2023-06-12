namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonAwardEditor
{
    [Parameter]
    public List<PersonAwardEditModel> Awards { get; set; }
        = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonAwardEditModel Model 
        = new();

    private string _years;

    private void Add()
    {
        if (Model.AwardType == null)
            return;

        foreach (int year in _years.ToIntArray())
        {
            Awards.Add(new PersonAwardEditModel() { AwardType = Model.AwardType, Year = year });
        }

        Model = new();
        _years = string.Empty;
    }
}
