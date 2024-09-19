namespace Memorabilia.Blazor.Pages.Person;

public partial class PersonCareerFranchiseRecordEditor
{
    [Parameter]
    public List<PersonCareerFranchiseRecordEditModel> CareerFranchiseRecords { get; set; }
        = [];

    [Parameter]
    public Franchise[] Franchises { get; set; }

    [Parameter]
    public Sport[] Sports { get; set; }

    protected PersonCareerFranchiseRecordEditModel Model
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

        CareerFranchiseRecords.Add(Model);

        Model = new PersonCareerFranchiseRecordEditModel();

        Model.SetFranchise(Franchises);
    }

    private void Edit(PersonCareerFranchiseRecordEditModel careerFranchiseRecord)
    {
        Model.Update(careerFranchiseRecord.Record, careerFranchiseRecord.Franchise, careerFranchiseRecord.RecordType);

        EditMode = EditModeType.Update;
    }

    private bool Filter(PersonCareerFranchiseRecordEditModel careerFranchiseRecord)
        => careerFranchiseRecord.Search(_search);

    private void Update()
    {
        CareerFranchiseRecords.Single(careerFranchiseRecord => careerFranchiseRecord.RecordType.Id == Model.RecordType.Id)
                              .Update(Model.Record, Model.Franchise);

        Model = new PersonCareerFranchiseRecordEditModel();

        Model.SetFranchise(Franchises);

        EditMode = EditModeType.Add;
    }
}
