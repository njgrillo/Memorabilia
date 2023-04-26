namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonSportEditor : ComponentBase
{
    [Parameter]
    public EventCallback OnSportChange { get; set; }

    [Parameter]
    public List<SavePersonSportViewModel> Sports { get; set; } = new();

    private SavePersonSportViewModel _viewModel = new();

    protected override void OnInitialized()
    {
        _viewModel.IsPrimary = Sports.Count == 0;
    }

    private async void Add()
    {
        if (_viewModel.Sport == null)
            return;

        Sports.Add(_viewModel);

        _viewModel = new SavePersonSportViewModel
        {
            IsPrimary = false
        };

        await OnSportChange.InvokeAsync();
    }

    private void Delete(SavePersonSportViewModel sport)
    {
        sport.IsDeleted = true;

        _viewModel.IsPrimary = Sports.All(sport => sport.IsDeleted);
    }
}
