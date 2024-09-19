namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonSingleSeasonFranchiseRecordEditor
{
    [Parameter]
    public Franchise[] Franchises { get; set; }

    [Parameter]
    public List<PersonSingleSeasonFranchiseRecordEditModel> SingleSeasonFranchiseRecords { get; set; }
        = [];

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonSingleSeasonFranchiseRecordEditModel Model
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    private string _search;    

    protected override void OnInitialized()
    {
        Model.SetFranchise(Franchises);
    }

    private void Add()
    {
        if (Model.RecordType == null)
            return;

        SingleSeasonFranchiseRecords.Add(Model);

        Model = new PersonSingleSeasonFranchiseRecordEditModel();

        Model.SetFranchise(Franchises);
    }

    private void Edit(PersonSingleSeasonFranchiseRecordEditModel singleSeasonFranchiseRecord)
    {
        Model.Update(
            singleSeasonFranchiseRecord.RecordType,
            singleSeasonFranchiseRecord.Franchise,
            singleSeasonFranchiseRecord.Year,
            singleSeasonFranchiseRecord.Record
            );

        EditMode = EditModeType.Update;
    }

    private bool Filter(PersonSingleSeasonFranchiseRecordEditModel singleSeasonFranchiseRecord)
        => singleSeasonFranchiseRecord.Search(_search);

    private void Update()
    {
        SingleSeasonFranchiseRecords.Single(singleSeasonFranchiseRecord => singleSeasonFranchiseRecord.RecordType.Id == Model.RecordType.Id).Update(
            Model.RecordType,
            Model.Franchise,
            Model.Year,
            Model.Record
            );

        Model = new();

        Model.SetFranchise(Franchises);

        EditMode = EditModeType.Add;
    }
}
