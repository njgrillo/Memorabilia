namespace Memorabilia.Blazor.Pages.Admin.Sports.Management.Accomplishments.Records;

public partial class EditSportRecords
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    private Dictionary<int, List<CareerRecordEditModel>> CareerRecordTypes
        => EditModel.CareerRecords
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.RecordTypeName)
                    .GroupBy(x => x.RecordTypeId)
                    .ToDictionary(g => g.Key, g => g.ToList());

    private SportRecordsEditModel EditModel
        = new();

    protected PersonModel[] People { get; set; }
        = [];

    private Dictionary<int, List<SingleSeasonRecordEditModel>> SingleSeasonRecordTypes
        => EditModel.SingleSeasonRecords
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.RecordTypeName)
                    .GroupBy(x => x.RecordTypeId)
                    .ToDictionary(g => g.Key, g => g.ToList());

    protected override async Task OnInitializedAsync()
    {
        await Load();
    }

    private void AddCareerRecord(CareerRecordEditModel careerRecord)
    {
        var newRecord = new CareerRecordEditModel(
                careerRecord.PersonId,
                careerRecord.RecordTypeId,
                careerRecord.Record
                );

        EditModel.CareerRecords.Add(newRecord);
    }

    private void AddSingleSeasonRecord(SingleSeasonRecordEditModel singleSeasonRecord)
    {
        var record = new SingleSeasonRecordEditModel(
                singleSeasonRecord.PersonId,
                singleSeasonRecord.RecordTypeId,
                singleSeasonRecord.Record,
                singleSeasonRecord.Year
                );

        EditModel.SingleSeasonRecords.Add(record);
    }

    private void DeleteCareerRecord(CareerRecordEditModel careerRecord)
    {
        CareerRecordEditModel deletedRecord
            = EditModel.CareerRecords.SingleOrDefault(
                x => (careerRecord.Id > 0 && x.Id == careerRecord.Id) ||
                     (careerRecord.TemporaryId.HasValue && x.TemporaryId == careerRecord.TemporaryId)
                );

        deletedRecord.IsDeleted = true;
    }

    private void DeleteSingleSeasonRecord(SingleSeasonRecordEditModel singleSeasonRecord)
    {
        SingleSeasonRecordEditModel deletedRecord
            = EditModel.SingleSeasonRecords.SingleOrDefault(
                x => (singleSeasonRecord.Id > 0 && x.Id == singleSeasonRecord.Id) ||
                     (singleSeasonRecord.TemporaryId.HasValue && x.TemporaryId == singleSeasonRecord.TemporaryId)
                );

        deletedRecord.IsDeleted = true;
    }

    private async Task Load()
    {
        if (EditModel.SportId == 0)
            return;

        SportRecordsViewModel viewModel = await Mediator.Send(new GetSportRecords(EditModel.SportId));

        EditModel = new SportRecordsEditModel(viewModel.SportId, viewModel.CareerRecords, viewModel.SingleSeasonRecords);

        Entity.Person[] people
            = await Mediator.Send(new GetPeople(SportId: EditModel.SportId));

        People = people.Select(person => new PersonModel(person)).ToArray();
    }

    private async Task OnSave()
    {
        await Mediator.Send(new SaveSportRecords.Command(EditModel));

        Snackbar.Add("Records were saved successfully!", Severity.Success);

        await Load();
    }

    private async Task OnSportChanged(int sportId)
    {
        EditModel.SportId = sportId;

        await Load();
    }
}
