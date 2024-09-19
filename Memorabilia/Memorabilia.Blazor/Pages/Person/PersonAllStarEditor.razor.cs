namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonAllStarEditor
{
    [Parameter]
    public List<PersonAllStarEditModel> AllStars { get; set; } 
        = [];

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonAllStarEditModel Model
        = new();

    private bool DisplaySportLeagueLevels 
        => Sports.Any(sport => sport == Sport.Basketball) ||
           Sports.Any(sport => sport == Sport.Football);

    private bool DisplaySports 
        => Sports.Length > 1;

    private string _search;
    private string _years;

    protected override void OnInitialized()
    {
        if (!DisplaySportLeagueLevels)
            return;

        Model.SetSportLeagueLevelId(Sports);
    }

    private void Add()
    {
        if (_years.IsNullOrEmpty())
            return;

        Model.SetSport(Sports);

        AllStars.AddRange(
            _years.ToIntArray().Select(year => new PersonAllStarEditModel
            {
                Sport = Model.Sport,
                SportLeagueLevelId = Model.SportLeagueLevelId,
                Year = year
            })
            );

        Model = new();

        _years = string.Empty;

        if (!DisplaySportLeagueLevels)
            return;

        Model.SetSportLeagueLevelId(Sports);
    }

    private bool Filter(PersonAllStarEditModel personAllStar)
        => personAllStar.Search(_search);
}
