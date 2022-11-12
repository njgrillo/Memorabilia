#nullable disable

namespace Memorabilia.Blazor.Controls.Person;

public partial class PersonSingleSeasonRecordEditor : ComponentBase
{
    [Parameter]
    public RecordType[] RecordTypes { get; set; } = RecordType.All;

    [Parameter]
    public List<SavePersonSingleSeasonRecordViewModel> SingleSeasonRecords { get; set; } = new();

    private bool _canAdd = true;
    private bool _canEditRecordType = true;
    private bool _canUpdate;
    private SavePersonSingleSeasonRecordViewModel _viewModel = new();

    private void Add()
    {
        SingleSeasonRecords.Add(_viewModel);

        _viewModel = new SavePersonSingleSeasonRecordViewModel();
    }

    private void Edit(SavePersonSingleSeasonRecordViewModel record)
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

        _viewModel = new SavePersonSingleSeasonRecordViewModel();

        _canAdd = true;
        _canEditRecordType = true;
        _canUpdate = false;
    }
}
