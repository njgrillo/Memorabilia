namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonCareerRecordEditor : ComponentBase
{
    [Parameter]
    public List<SavePersonCareerRecordViewModel> CareerRecords { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    private bool _canAdd = true;
    private bool _canEditRecordType = true;
    private bool _canUpdate;
    private SavePersonCareerRecordViewModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.RecordType == null)
            return;

        CareerRecords.Add(_viewModel);

        _viewModel = new SavePersonCareerRecordViewModel();
    }

    private void Edit(SavePersonCareerRecordViewModel record)
    {
        _viewModel.RecordType = record.RecordType;
        _viewModel.Record = record.Record;

        _canAdd = false;
        _canEditRecordType = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var record = CareerRecords.Single(record => record.RecordType.Id == _viewModel.RecordType.Id);

        record.Record = _viewModel.Record;

        _viewModel = new SavePersonCareerRecordViewModel();

        _canAdd = true;
        _canEditRecordType = true;
        _canUpdate = false;
    }
}
