namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAllStarEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonAllStarViewModel> AllStars { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    private bool DisplaySportLeagueLevels => Sports.Any(sport => sport == Sport.Basketball);

    private bool DisplaySports => Sports.Length > 1;

    private SavePersonAllStarViewModel _viewModel = new();
    private string _years;

    protected override void OnInitialized()
    {
        if (!DisplaySportLeagueLevels)
            return;

        _viewModel.SportLeagueLevelId = SportLeagueLevel.NationalBasketballAssociation.Id;
    }

    private void Add()
    {
        if (Sports.Length == 1)
            _viewModel.Sport = Sports.FirstOrDefault();

        var years = _years.ToIntArray();

        foreach (var year in years)
        {
            AllStars.Add(new SavePersonAllStarViewModel
            {   Sport = _viewModel.Sport, 
                SportLeagueLevelId = _viewModel.SportLeagueLevelId,
                Year = year 
            });
        }

        _viewModel = new();
        _years = string.Empty;

        if (!DisplaySportLeagueLevels)
            return;

        _viewModel.SportLeagueLevelId = SportLeagueLevel.NationalBasketballAssociation.Id;
    }
}
