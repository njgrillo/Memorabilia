#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonAccomplishmentEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonAccomplishmentViewModel> Accomplishments { get; set; } = new();

    [Parameter]
    public AccomplishmentType[] AccomplishmentTypes { get; set; } = AccomplishmentType.All;

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
        _viewModel.AccomplishmentTypeId = accomplishment.AccomplishmentTypeId;
        _viewModel.Year = accomplishment.Year;
        _viewModel.Date = accomplishment.Date;

        _canAdd = false;
        _canEditAccomplishmentType = false;
        _canUpdate = true;
    }

    private void Remove(int accomplishmentTypeId, DateTime? date, int? year)
    {
        var accomplishment = Accomplishments.SingleOrDefault(accomplishment => accomplishment.AccomplishmentTypeId == accomplishmentTypeId
                                                             && ((accomplishment.Date.HasValue && accomplishment.Date == date)
                                                                  || (accomplishment.Year.HasValue && accomplishment.Year == year)));

        if (accomplishment == null)
            return;

        accomplishment.IsDeleted = true;
    }

    private void Update()
    {
        var accomplishment = Accomplishments.Single(accomplishment => accomplishment.AccomplishmentTypeId == _viewModel.AccomplishmentTypeId);

        accomplishment.Year = _viewModel.Year;
        accomplishment.Date = _viewModel.Date;

        _viewModel = new SavePersonAccomplishmentViewModel();

        _canAdd = true;
        _canEditAccomplishmentType = true;
        _canUpdate = false;
    }
}