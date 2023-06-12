namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonSingleSeasonRecordEditor
{
    [Parameter]
    public List<PersonSingleSeasonRecordEditModel> SingleSeasonRecords { get; set; } 
        = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonSingleSeasonRecordEditModel Model
        = new();

    private bool _canAdd 
        = true;

    private bool _canEditRecordType 
        = true;

    private bool _canUpdate;    

    private void Add()
    {
        if (Model.RecordType == null)
            return;

        SingleSeasonRecords.Add(Model);

        Model = new PersonSingleSeasonRecordEditModel();
    }

    private void Edit(PersonSingleSeasonRecordEditModel record)
    {
        Model.RecordType = record.RecordType;
        Model.Year = record.Year;
        Model.Record = record.Record;

        _canAdd = false;
        _canEditRecordType = false;
        _canUpdate = true;
    }

    private void Update()
    {
        PersonSingleSeasonRecordEditModel record 
            = SingleSeasonRecords.Single(record => record.RecordType.Id == Model.RecordType.Id);

        record.RecordType = Model.RecordType;
        record.Year = Model.Year;
        record.Record = Model.Record;

        Model = new();

        _canAdd = true;
        _canEditRecordType = true;
        _canUpdate = false;
    }
}
