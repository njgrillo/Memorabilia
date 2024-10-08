namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonCareerRecordEditor
{
    [Parameter]
    public List<PersonCareerRecordEditModel> CareerRecords { get; set; } 
        = [];

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonCareerRecordEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private string _search;    

    private void Add()
    {
        if (Model.RecordType == null)
            return;

        CareerRecords.Add(Model);

        Model = new PersonCareerRecordEditModel();
    }

    private void Edit(PersonCareerRecordEditModel record)
    {
        Model.Update(record.Record, record.RecordType);

        EditMode = EditModeType.Update;
    }

    private bool Filter(PersonCareerRecordEditModel careerRecord)
        => careerRecord.Search(_search);

    private void Update()
    {
        CareerRecords.SingleOrDefault(record => record.RecordType?.Id == Model.RecordType?.Id)?
                     .Update(Model.Record);

        Model = new PersonCareerRecordEditModel();

        EditMode = EditModeType.Add;
    }
}
