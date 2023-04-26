namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAwardEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonAwardViewModel> Awards { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    private SavePersonAwardViewModel _viewModel = new();
    private string _years;

    private void Add()
    {
        if (_viewModel.AwardType == null)
            return;

        foreach (var year in _years.ToIntArray())
        {
            Awards.Add(new SavePersonAwardViewModel() { AwardType = _viewModel.AwardType, Year = year });
        }

        _viewModel = new SavePersonAwardViewModel();
        _years = string.Empty;
    }
}
