namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAwardEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonAwardViewModel> Awards { get; set; } = new();

    [Parameter]
    public int[] SportIds { get; set; }

    private SavePersonAwardViewModel _viewModel = new();
    private string _years;

    private void Add()
    {
        foreach (var year in _years.ToIntArray())
        {
            Awards.Add(new SavePersonAwardViewModel() { AwardType = _viewModel.AwardType, Year = year });
        }

        _viewModel = new SavePersonAwardViewModel();
        _years = string.Empty;
    }
}
