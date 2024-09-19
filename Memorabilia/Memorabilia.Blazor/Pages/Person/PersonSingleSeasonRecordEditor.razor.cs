namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonSingleSeasonRecordEditor
{  
    [Parameter]
    public List<PersonSingleSeasonRecordEditModel> SingleSeasonRecords { get; set; } 
        = [];

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonSingleSeasonRecordEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private string _search;    

    private void Add()
    {
        if (Model.RecordType == null)
            return;

        SingleSeasonRecords.Add(Model);

        Model = new PersonSingleSeasonRecordEditModel();
    }

    private void Edit(PersonSingleSeasonRecordEditModel record)
    {
        Model.Update(record.RecordType, record.Year, record.Record);

        EditMode = EditModeType.Update;
    }

    private bool Filter(PersonSingleSeasonRecordEditModel singleSeasonRecord)
        => singleSeasonRecord.Search(_search);

    private void Update()
    {
        SingleSeasonRecords.Single(record => record.RecordType.Id == Model.RecordType.Id).Update(Model.RecordType, Model.Year, Model.Record);

        Model = new();

        EditMode = EditModeType.Add;
    }
}
