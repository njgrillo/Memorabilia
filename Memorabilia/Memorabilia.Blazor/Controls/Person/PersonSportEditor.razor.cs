namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonSportEditor : ComponentBase
{
    [Parameter]
    public EventCallback OnSportChange { get; set; }

    [Parameter]
    public List<SavePersonSportViewModel> Sports { get; set; } = new();

    private SavePersonSportViewModel _viewModel = new();

    private async void Add()
    {
        if (_viewModel.Sport == null)
            return;

        Sports.Add(_viewModel);

        _viewModel = new SavePersonSportViewModel();

        await OnSportChange.InvokeAsync();
    }
}
