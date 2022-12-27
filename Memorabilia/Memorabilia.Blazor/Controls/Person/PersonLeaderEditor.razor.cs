namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonLeaderEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonLeaderViewModel> Leaders { get; set; } = new();

    [Parameter]
    public int[] SportIds { get; set; }

    private SavePersonLeaderViewModel _viewModel = new();
    private string _years;

    private void Add()
    {
        foreach (var year in _years.ToIntArray())
        {
            Leaders.Add(new SavePersonLeaderViewModel() { LeaderType = _viewModel.LeaderType, Year = year });
        }

        _viewModel = new SavePersonLeaderViewModel();
        _years = string.Empty;
    }
}
