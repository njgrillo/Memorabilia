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

    protected EditModeType EditMode
        = EditModeType.Add;

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

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PersonCareerRecordEditModel record 
            = CareerRecords.Single(record => record.RecordType.Id == Model.RecordType.Id);

        record.Record = Model.Record;

        Model = new PersonCareerRecordEditModel();

        EditMode = EditModeType.Add;
    }
}
