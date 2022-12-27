namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAccomplishmentEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonAccomplishmentViewModel> Accomplishments { get; set; } = new();

    [Parameter]
    public int[] SportIds { get; set; }

    protected bool IsDateAccomplishment => AccomplishmentType.IsDateAccomplishment(_viewModel.AccomplishmentType?.Id ?? 0);

    protected bool IsYearAccomplishment => AccomplishmentType.IsYearAccomplishment(_viewModel.AccomplishmentType?.Id ?? 0);

    private bool _canAdd = true;
    private bool _canEditAccomplishmentType = true;
    private bool _canUpdate;
    private SavePersonAccomplishmentViewModel _viewModel = new();

    private void Add()
    {
        Accomplishments.Add(_viewModel);

        _viewModel = new SavePersonAccomplishmentViewModel();
    }

    private void Edit(SavePersonAccomplishmentViewModel accomplishment)
    {
        _viewModel.AccomplishmentType = accomplishment.AccomplishmentType;
        _viewModel.Year = accomplishment.Year;
        _viewModel.Date = accomplishment.Date;

        _canAdd = false;
        _canEditAccomplishmentType = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var accomplishment = Accomplishments.Single(accomplishment => accomplishment.AccomplishmentType.Id == _viewModel.AccomplishmentType.Id);

        accomplishment.Year = _viewModel.Year;
        accomplishment.Date = _viewModel.Date;

        _viewModel = new SavePersonAccomplishmentViewModel();

        _canAdd = true;
        _canEditAccomplishmentType = true;
        _canUpdate = false;
    }
}