#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonCareerRecordEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonCareerRecordViewModel> CareerRecords { get; set; } = new();

    [Parameter]
    public RecordType[] RecordTypes { get; set; } = RecordType.All;

    private bool _canAdd = true;
    private bool _canEditRecordType = true;
    private bool _canUpdate;
    private SavePersonCareerRecordViewModel _viewModel = new();

    private void Add()
    {
        CareerRecords.Add(_viewModel);

        _viewModel = new SavePersonCareerRecordViewModel();
    }

    private void Edit(SavePersonCareerRecordViewModel record)
    {
        _viewModel.RecordTypeId = record.RecordTypeId;
        _viewModel.Amount = record.Amount;

        _canAdd = false;
        _canEditRecordType = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var record = CareerRecords.Single(record => record.RecordTypeId == _viewModel.RecordTypeId);

        record.Amount = _viewModel.Amount;

        _viewModel = new SavePersonCareerRecordViewModel();

        _canAdd = true;
        _canEditRecordType = true;
        _canUpdate = false;
    }
}
