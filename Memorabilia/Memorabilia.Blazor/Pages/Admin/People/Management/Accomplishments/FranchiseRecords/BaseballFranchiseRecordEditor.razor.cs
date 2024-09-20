namespace Memorabilia.Blazor.Pages.Admin.People.Management.Accomplishments.FranchiseRecords;

public partial class BaseballFranchiseRecordEditor
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public List<CareerFranchiseRecordEditModel> CareerFranchiseRecords { get; set; }
        = [];

    [Parameter]
    public Franchise Franchise { get; set; }

    [Parameter]
    public EventCallback<CareerFranchiseRecordEditModel> OnCareerRecordAdded { get; set; }

    [Parameter]
    public EventCallback<CareerFranchiseRecordEditModel> OnCareerRecordDeleted { get; set; }

    [Parameter]
    public EventCallback<SingleSeasonFranchiseRecordEditModel> OnSingleSeasonRecordAdded { get; set; }

    [Parameter]
    public EventCallback<SingleSeasonFranchiseRecordEditModel> OnSingleSeasonRecordDeleted { get; set; }

    [Parameter]
    public PersonModel[] People { get; set; }
        = [];

    [Parameter]
    public List<SingleSeasonFranchiseRecordEditModel> SingleSeasonFranchiseRecords { get; set; }
        = [];

    public Dictionary<int, List<CareerFranchiseRecordEditModel>> CareerFranchiseRecordTypes
        => CareerFranchiseRecords.Where(x => !x.IsDeleted)
                                 .OrderBy(x => x.RecordTypeName)
                                 .GroupBy(x => x.RecordTypeId)
                                 .ToDictionary(g => g.Key, g => g.ToList());

    public Dictionary<int, List<SingleSeasonFranchiseRecordEditModel>> SingleSeasonFranchiseRecordTypes
        => SingleSeasonFranchiseRecords.Where(x => !x.IsDeleted)
                                       .OrderBy(x => x.RecordTypeName)
                                       .GroupBy(x => x.RecordTypeId)
                                       .ToDictionary(g => g.Key, g => g.ToList());

    public Sport Sport
        => Franchise.GetSport(Franchise?.Id ?? 0);

    private bool _loaded;    

    protected override void OnParametersSet()
    {
        if (_loaded || Franchise is null)
            return;

        AddCareerFranchiseRecords();
        AddSingleSeasonFranchiseRecords();

        _loaded = true;
    }

    private async Task AddCareerFranchiseRecord(CareerFranchiseRecordEditModel careerFranchiseRecord)
    {
        await OnCareerRecordAdded.InvokeAsync(careerFranchiseRecord);
    }

    private void AddCareerFranchiseRecords()
    {
        int[] careerFranchiseRecordTypeIds =
            CareerFranchiseRecords.Select(x => x.RecordTypeId).ToArray();

        CareerFranchiseRecordEditModel[] careerFranchiseRecords
            = RecordType.BaseballCareerFranchiseLeader
                        .Where(x => !careerFranchiseRecordTypeIds.Contains(x.Id))
                        .Select(x => new CareerFranchiseRecordEditModel(Franchise.Id, x.Id))
                        .ToArray();

        CareerFranchiseRecords.AddRange(careerFranchiseRecords);
    }

    private async Task AddSingleSeasonFranchiseRecord(SingleSeasonFranchiseRecordEditModel singleSeasonFranchiseRecord)
    {
        await OnSingleSeasonRecordAdded.InvokeAsync(singleSeasonFranchiseRecord);
    }

    private void AddSingleSeasonFranchiseRecords()
    {
        int[] singleSeasonFranchiseRecordTypeIds =
            SingleSeasonFranchiseRecords.Select(x => x.RecordTypeId).ToArray();

        SingleSeasonFranchiseRecordEditModel[] singleSeasonFranchiseRecords
            = RecordType.BaseballSingleSeasonFranchiseLeader
                        .Where(x => !singleSeasonFranchiseRecordTypeIds.Contains(x.Id))
                        .Select(x => new SingleSeasonFranchiseRecordEditModel(Franchise.Id, x.Id))
                        .ToArray();

        SingleSeasonFranchiseRecords.AddRange(singleSeasonFranchiseRecords);
    }

    private async Task DeleteCareerFranchiseRecord(CareerFranchiseRecordEditModel careerFranchiseRecord)
    {
        await OnCareerRecordDeleted.InvokeAsync(careerFranchiseRecord);
    }

    private async Task DeleteSingleSeasonFranchiseRecord(SingleSeasonFranchiseRecordEditModel singleSeasonFranchiseRecord)
    {
        await OnSingleSeasonRecordDeleted.InvokeAsync(singleSeasonFranchiseRecord);
    }
}
