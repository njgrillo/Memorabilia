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

    protected EditModeType EditMode
        = EditModeType.Add;

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

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PersonSingleSeasonRecordEditModel record 
            = SingleSeasonRecords.Single(record => record.RecordType.Id == Model.RecordType.Id);

        record.RecordType = Model.RecordType;
        record.Year = Model.Year;
        record.Record = Model.Record;

        Model = new();

        EditMode = EditModeType.Add;
    }
}
