namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonAwardEditor
{
    [Parameter]
    public List<PersonAwardEditModel> Awards { get; set; }
        = [];

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonAwardEditModel Model 
        = new();

    private string _search;
    private string _years;

    private void Add()
    {
        if (Model.AwardType == null)
            return;

        Awards.AddRange(_years.ToIntArray().Select(year => new PersonAwardEditModel(Model.AwardType, year)));

        Model = new();

        _years = string.Empty;
    }

    private bool Filter(PersonAwardEditModel personAward)
        => personAward.Search(_search);
}
