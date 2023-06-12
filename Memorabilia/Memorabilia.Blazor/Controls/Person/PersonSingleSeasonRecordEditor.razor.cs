namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonSingleSeasonRecordEditor : ComponentBase
{
    [Parameter]
    public List<PersonSingleSeasonRecordEditModel> SingleSeasonRecords { get; set; } = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    private bool _canAdd = true;
    private bool _canEditRecordType = true;
    private bool _canUpdate;
    private PersonSingleSeasonRecordEditModel _viewModel = new();

    private void Add()
    {
        if (_viewModel.RecordType == null)
            return;

        SingleSeasonRecords.Add(_viewModel);

        _viewModel = new PersonSingleSeasonRecordEditModel();
    }

    private void Edit(PersonSingleSeasonRecordEditModel record)
    {
        _viewModel.RecordType = record.RecordType;
        _viewModel.Year = record.Year;
        _viewModel.Record = record.Record;

        _canAdd = false;
        _canEditRecordType = false;
        _canUpdate = true;
    }

    private void Update()
    {
        var record = SingleSeasonRecords.Single(record => record.RecordType.Id == _viewModel.RecordType.Id);

        record.RecordType = _viewModel.RecordType;
        record.Year = _viewModel.Year;
        record.Record = _viewModel.Record;

        _viewModel = new PersonSingleSeasonRecordEditModel();

        _canAdd = true;
        _canEditRecordType = true;
        _canUpdate = false;
    }
}
