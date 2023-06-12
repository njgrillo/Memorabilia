namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAwardEditor : ComponentBase
{
    [Parameter]
    public List<PersonAwardEditModel> Awards { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    private PersonAwardEditModel _viewModel = new();
    private string _years;

    private void Add()
    {
        if (_viewModel.AwardType == null)
            return;

        foreach (var year in _years.ToIntArray())
        {
            Awards.Add(new PersonAwardEditModel() { AwardType = _viewModel.AwardType, Year = year });
        }

        _viewModel = new PersonAwardEditModel();
        _years = string.Empty;
    }
}
