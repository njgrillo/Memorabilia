namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonCareerRecordEditor
{
    [Parameter]
    public List<PersonCareerRecordEditModel> CareerRecords { get; set; } 
        = new();

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonCareerRecordEditModel Model
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

        CareerRecords.Add(Model);

        Model = new PersonCareerRecordEditModel();
    }

    private void Edit(PersonCareerRecordEditModel record)
    {
        Model.RecordType = record.RecordType;
        Model.Record = record.Record;

        _canAdd = false;
        _canEditRecordType = false;
        _canUpdate = true;
    }

    private void Update()
    {
        PersonCareerRecordEditModel record 
            = CareerRecords.Single(record => record.RecordType.Id == Model.RecordType.Id);

        record.Record = Model.Record;

        Model = new PersonCareerRecordEditModel();

        _canAdd = true;
        _canEditRecordType = true;
        _canUpdate = false;
    }
}
