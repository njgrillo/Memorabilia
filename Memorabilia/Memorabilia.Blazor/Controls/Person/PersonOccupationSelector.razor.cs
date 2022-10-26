#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonOccupationSelector : ComponentBase
{
    [Parameter]
    public List<SavePersonOccupationViewModel> Occupations { get; set; } = new();

    private bool _canAdd = true;
    private bool _canEditOccupation = true;
    private bool _canUpdate;
    private SavePersonOccupationViewModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.OccupationId == 0 || _viewModel.OccupationTypeId == 0)
            return;

        Occupations.Add(_viewModel);

        _viewModel = new SavePersonOccupationViewModel();
    }

    private void Edit(SavePersonOccupationViewModel occupation)
    {
        _viewModel.OccupationId = occupation.OccupationId;
        _viewModel.OccupationTypeId = occupation.OccupationTypeId;

        _canAdd = false;
        _canEditOccupation = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var occupation = Occupations.Single(occupation => occupation.OccupationId == _viewModel.OccupationId);

        occupation.OccupationId = _viewModel.OccupationId;
        occupation.OccupationTypeId = _viewModel.OccupationTypeId;

        _viewModel = new SavePersonOccupationViewModel();

        _canAdd = true;
        _canEditOccupation = true;
        _canUpdate = false;
    }
}
