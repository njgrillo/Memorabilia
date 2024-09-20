namespace Memorabilia.Blazor.Pages.Admin.People.Management.Accomplishments.FranchiseRecords;

public partial class EditFranchiseRecords
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public int FranchiseId { get; set; }

    private FranchiseRecordEditModel EditModel
        = new();

    protected PersonModel[] People { get; set; }
        = [];

    private bool _peopleLoaded;

    protected override async Task OnInitializedAsync()
    {   
        await Load();

        if (_peopleLoaded)
            return;

        Entity.Person[] people
            = await Mediator.Send(new GetPeople(SportId: EditModel.Sport?.Id));

        People = people.Select(person => new PersonModel(person)).ToArray();

        _peopleLoaded = true;
    }

    private void AddCareerFranchiseRecord(CareerFranchiseRecordEditModel careerFranchiseRecord)
    {
        var newRecord = new CareerFranchiseRecordEditModel(
                careerFranchiseRecord.FranchiseId,
                careerFranchiseRecord.RecordTypeId,
                careerFranchiseRecord.Record,
                Guid.NewGuid()
                );

        EditModel.CareerFranchiseRecords.Add(newRecord);
    }

    private void AddSingleSeasonFranchiseRecord(SingleSeasonFranchiseRecordEditModel singleSeasonFranchiseRecord)
    {
        var newRecord = new SingleSeasonFranchiseRecordEditModel(
                singleSeasonFranchiseRecord.FranchiseId,
                singleSeasonFranchiseRecord.RecordTypeId,
                singleSeasonFranchiseRecord.Record,
                Guid.NewGuid()
                );

        EditModel.SingleSeasonFranchiseRecords.Add(singleSeasonFranchiseRecord);
    }

    private void DeleteCareerFranchiseRecord(CareerFranchiseRecordEditModel careerFranchiseRecord)
    {
        CareerFranchiseRecordEditModel deletedRecord
            = EditModel.CareerFranchiseRecords.SingleOrDefault(
                x => (careerFranchiseRecord.Person.Id > 0 && x.Person.Id == careerFranchiseRecord.Person.Id) ||
                     (careerFranchiseRecord.TemporaryId.HasValue && x.TemporaryId == careerFranchiseRecord.TemporaryId)
                );

        deletedRecord.IsDeleted = true;
    }

    private void DeleteSingleSeasonFranchiseRecord(SingleSeasonFranchiseRecordEditModel singleSeasonFranchiseRecord)
    {
        SingleSeasonFranchiseRecordEditModel deletedRecord
            = EditModel.SingleSeasonFranchiseRecords.SingleOrDefault(
                x => (singleSeasonFranchiseRecord.Person.Id > 0 && x.Person.Id == singleSeasonFranchiseRecord.Person.Id) ||
                     (singleSeasonFranchiseRecord.TemporaryId.HasValue && x.TemporaryId == singleSeasonFranchiseRecord.TemporaryId)
                );

        deletedRecord.IsDeleted = true;
    }

    private async Task Load()
    {
        if (FranchiseId == 0)
            return;

        Entity.Franchise franchise = await Mediator.Send(new GetFranchise(FranchiseId));

        EditModel = new FranchiseRecordEditModel(franchise);    
    }

    private async Task OnSave()
    {
        await Mediator.Send(new SaveFranchiseRecords.Command(EditModel));

        Snackbar.Add("Franchise Records were saved successfully!", Severity.Success);
    }
}
