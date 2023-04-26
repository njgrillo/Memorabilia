using Memorabilia.Domain.Enums;

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonPositionEditor
{
    [Parameter]
    public List<SavePersonPositionViewModel> Positions { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; } = Array.Empty<Sport>();

    private SavePersonPositionViewModel _viewModel = new();

    protected override void OnParametersSet()
    {
        if (Positions.Any())
            _viewModel.PositionType = PositionType.Secondary;
    }

    private void Add()
    {
        if (_viewModel.Position == null)
            return;

        Positions.Add(_viewModel);

        _viewModel = new SavePersonPositionViewModel
        {
            PositionType = PositionType.Secondary
        };
    }

    private void Delete(SavePersonPositionViewModel position)
    {
        position.IsDeleted = true;

        _viewModel.PositionType = Positions.Any(position => !position.IsDeleted)
            ? PositionType.Secondary
            : PositionType.Primary;
    }

    private void OnPositionTypeChange(bool value)
    {
        _viewModel.PositionType = value ? PositionType.Primary : PositionType.Secondary;
    }
}
