namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAllStarEditor : ComponentBase
{
    [Parameter]
    public List<PersonAllStarEditModel> AllStars { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    private bool DisplaySportLeagueLevels => Sports.Any(sport => sport == Sport.Basketball) ||
        Sports.Any(sport => sport == Sport.Football);

    private bool DisplaySports => Sports.Length > 1;

    private PersonAllStarEditModel _viewModel = new();
    private string _years;

    protected override void OnInitialized()
    {
        if (!DisplaySportLeagueLevels)
            return;

        if (Sports.Any(sport => sport == Sport.Basketball))
            _viewModel.SportLeagueLevelId = SportLeagueLevel.NationalBasketballAssociation.Id;

        if (Sports.Any(sport => sport == Sport.Football))
            _viewModel.SportLeagueLevelId = SportLeagueLevel.NationalFootballLeague.Id;
    }

    private void Add()
    {
        if (_years.IsNullOrEmpty())
            return;

        if (Sports.Length == 1)
            _viewModel.Sport = Sports.FirstOrDefault();

        var years = _years.ToIntArray();

        foreach (var year in years)
        {
            AllStars.Add(new PersonAllStarEditModel
            {   Sport = _viewModel.Sport, 
                SportLeagueLevelId = _viewModel.SportLeagueLevelId,
                Year = year 
            });
        }

        _viewModel = new();
        _years = string.Empty;

        if (!DisplaySportLeagueLevels)
            return;

        if (Sports.Any(sport => sport == Sport.Basketball))
            _viewModel.SportLeagueLevelId = SportLeagueLevel.NationalBasketballAssociation.Id;

        if (Sports.Any(sport => sport == Sport.Football))
            _viewModel.SportLeagueLevelId = SportLeagueLevel.NationalFootballLeague.Id;
    }
}
