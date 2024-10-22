namespace Memorabilia.Blazor.Pages.Admin.Sports.Management.Accomplishments.Leaders;

public partial class EditSportLeaders
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }       

    private SportLeadersEditModel EditModel
        = new();

    private Dictionary<int, List<LeaderEditModel>> LeaderTypes
        => EditModel.Leaders
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.LeaderTypeName)
                    .GroupBy(x => x.LeaderTypeId)
                    .ToDictionary(g => g.Key, g => g.ToList());

    protected PersonModel[] People { get; set; }
        = [];

    protected override async Task OnInitializedAsync()
    {
        await Load();
    }

    private void AddLeader(LeaderEditModel leader)
    {
        var newLeader = new LeaderEditModel(
                leader.PersonId,
                leader.LeaderTypeId,
                leader.Year
                );

        EditModel.Leaders.Add(newLeader);
    }

    private void DeleteLeader(LeaderEditModel leader)
    {
        LeaderEditModel deletedLeader
            = EditModel.Leaders.SingleOrDefault(
                x => (leader.Id > 0 && x.Id == leader.Id) ||
                     (leader.TemporaryId.HasValue && x.TemporaryId == leader.TemporaryId)
                );

        deletedLeader.IsDeleted = true;
    }

    private async Task Load()
    {
        if (EditModel.SportId == 0 || EditModel.Year == 0)
            return;

        SportLeadersViewModel viewModel = await Mediator.Send(new GetSportLeaders(EditModel.SportId, EditModel.Year));

        EditModel = new SportLeadersEditModel(viewModel.SportId, EditModel.Year, viewModel.Leaders);

        Entity.Person[] people
            = await Mediator.Send(new GetPeople(SportId: EditModel.SportId));

        People = people.Select(person => new PersonModel(person)).ToArray();
    }

    private async Task OnSave()
    {
        await Mediator.Send(new SaveSportLeaders.Command(EditModel));

        Snackbar.Add("Leaders were saved successfully!", Severity.Success);

        await Load();
    }

    private async Task OnSportChanged(int sportId)
    {
        EditModel.SportId = sportId;

        await Load();
    }

    private async Task OnYearChanged(int year)
    {
        EditModel.Year = year;

        await Load();
    }
}
