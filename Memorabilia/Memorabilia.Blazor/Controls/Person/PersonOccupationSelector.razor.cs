namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonOccupationSelector : ComponentBase
{
    [Parameter]
    public List<SavePersonOccupationViewModel> Occupations { get; set; } = new();

    [Parameter]
    public EventCallback OnOccupationChange { get; set; }

    private bool _canAdd = true;
    private bool _canEditOccupation = true;
    private bool _canUpdate;
    private SavePersonOccupationViewModel _viewModel = new();

    protected override void OnParametersSet()
    {
        if (Occupations.Any())
            _viewModel.OccupationType = OccupationType.Secondary;
    }

    private async void Add()
    {
        if (_viewModel.Occupation == null || _viewModel.OccupationType == null)
            return;

        Occupations.Add(_viewModel);

        _viewModel = new SavePersonOccupationViewModel
        {
            OccupationType = OccupationType.Secondary
        };

        await OnOccupationChange.InvokeAsync();
    }

    private void Delete(SavePersonOccupationViewModel occupation)
    {
        occupation.IsDeleted = true;

        _viewModel.OccupationType = Occupations.Any(occupation => !occupation.IsDeleted) 
            ? OccupationType.Secondary
            : OccupationType.Primary;
    }

    private async void Edit(SavePersonOccupationViewModel occupation)
    {
        _viewModel.Occupation = occupation.Occupation;
        _viewModel.OccupationType = occupation.OccupationType;

        _canAdd = false;
        _canEditOccupation = false;
        _canUpdate = true;

        await OnOccupationChange.InvokeAsync();
    }

    private void OnOccupationTypeChange(bool value)
    {
        _viewModel.OccupationType = value ? OccupationType.Primary : OccupationType.Secondary;
    }

    private async void Update()
    {
        var occupation = Occupations.Single(occupation => occupation.Occupation.Id == _viewModel.Occupation.Id);

        occupation.Occupation = _viewModel.Occupation;
        occupation.OccupationType = _viewModel.OccupationType;

        _viewModel = new SavePersonOccupationViewModel();

        _canAdd = true;
        _canEditOccupation = true;
        _canUpdate = false;

        await OnOccupationChange.InvokeAsync();
    }
}
