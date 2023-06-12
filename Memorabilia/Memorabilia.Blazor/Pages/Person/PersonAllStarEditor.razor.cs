namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonAllStarEditor
{
    [Parameter]
    public List<PersonAllStarEditModel> AllStars { get; set; } 
        = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonAllStarEditModel Model
        = new();

    private bool DisplaySportLeagueLevels 
        => Sports.Any(sport => sport == Sport.Basketball) ||
           Sports.Any(sport => sport == Sport.Football);

    private bool DisplaySports 
        => Sports.Length > 1;    

    private string _years;

    protected override void OnInitialized()
    {
        if (!DisplaySportLeagueLevels)
            return;

        if (Sports.Any(sport => sport == Sport.Basketball))
            Model.SportLeagueLevelId = SportLeagueLevel.NationalBasketballAssociation.Id;

        if (Sports.Any(sport => sport == Sport.Football))
            Model.SportLeagueLevelId = SportLeagueLevel.NationalFootballLeague.Id;
    }

    private void Add()
    {
        if (_years.IsNullOrEmpty())
            return;

        if (Sports.Length == 1)
            Model.Sport = Sports.FirstOrDefault();

        int[] years = _years.ToIntArray();

        foreach (var year in years)
        {
            AllStars.Add(new PersonAllStarEditModel
            {   Sport = Model.Sport, 
                SportLeagueLevelId = Model.SportLeagueLevelId,
                Year = year 
            });
        }

        Model = new();
        _years = string.Empty;

        if (!DisplaySportLeagueLevels)
            return;

        if (Sports.Any(sport => sport == Sport.Basketball))
            Model.SportLeagueLevelId = SportLeagueLevel.NationalBasketballAssociation.Id;

        if (Sports.Any(sport => sport == Sport.Football))
            Model.SportLeagueLevelId = SportLeagueLevel.NationalFootballLeague.Id;
    }
}
