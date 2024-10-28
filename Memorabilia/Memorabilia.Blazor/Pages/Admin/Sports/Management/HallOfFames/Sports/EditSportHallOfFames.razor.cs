namespace Memorabilia.Blazor.Pages.Admin.Sports.Management.HallOfFames.Sports;

public partial class EditSportHallOfFames
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected EditModeType EditMode
        = EditModeType.Add;

    private SportHallOfFameEditModel EditModel
        = new();

    private HallOfFameEditModel HallOfFameEditModel
        = new();

    protected PersonModel[] People { get; set; }
        = [];

    private string _search;

    private void Add()
    {
        if (HallOfFameEditModel.SportLeagueLevelId == 0)
            return;

        EditModel.HallOfFames.Add(HallOfFameEditModel);

        HallOfFameEditModel = new();
    }

    private void Edit(HallOfFameEditModel hallOfFame)
    {
        HallOfFameEditModel.BallotNumber = hallOfFame.BallotNumber;
        HallOfFameEditModel.InductionYear = hallOfFame.InductionYear;
        HallOfFameEditModel.Person = hallOfFame.Person;
        HallOfFameEditModel.SportLeagueLevelId = EditModel.SportLeagueLevelId;
        HallOfFameEditModel.VotePercentage = hallOfFame.VotePercentage;

        EditMode = EditModeType.Update;
    }

    private async Task Load()
    {
        if (EditModel.SportLeagueLevelId == 0)
            return;

        SportHallOfFameViewModel viewModel = await Mediator.Send(new GetSportHallOfFamers(EditModel.SportLeagueLevelId));

        EditModel = new SportHallOfFameEditModel(viewModel.SportLeageLevelId, viewModel.HallOfFamers);

        var sport = SportLeagueLevel.Find(viewModel.SportLeageLevelId).Sport;

        Entity.Person[] people
            = await Mediator.Send(new GetPeople(SportId: sport.Id));

        People = people.Select(person => new PersonModel(person)).ToArray();
    }

    private async Task OnSave()
    {
        await Mediator.Send(new SaveSportHallOfFamers.Command(EditModel));

        Snackbar.Add("Hall of Famers were saved successfully!", Severity.Success);

        await Load();
    }

    private async Task OnSportLeagueLevelChanged(int sportLeagueLevelId)
    {
        EditModel.SportLeagueLevelId = sportLeagueLevelId;

        await Load();
    }

    private void Update()
    {
        HallOfFameEditModel hallOfFame
            = EditModel.HallOfFames.SingleOrDefault(hof => hof.SportLeagueLevelId == HallOfFameEditModel.SportLeagueLevelId);

        if (hallOfFame is not null)
        {
            hallOfFame.Person = HallOfFameEditModel.Person;
            hallOfFame.BallotNumber = HallOfFameEditModel.BallotNumber;
            hallOfFame.InductionYear = HallOfFameEditModel.InductionYear;
            hallOfFame.VotePercentage = HallOfFameEditModel.VotePercentage;
        }

        HallOfFameEditModel = new();

        EditMode = EditModeType.Add;
    }
}
