#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonSportEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonSportViewModel> Sports { get; set; } = new();

    private SavePersonSportViewModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.SportId == 0)
            return;

        Sports.Add(_viewModel);

        _viewModel = new SavePersonSportViewModel();
    }
}
