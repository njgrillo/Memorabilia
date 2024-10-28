namespace Memorabilia.Blazor.Pages.Admin.Teams.Management.HallOfFames;

public partial class EditFranchiseHallOfFames
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected EditModeType EditMode
        = EditModeType.Add;

    private FranchiseHallOfFamesEditModel EditModel
        = new();

    private FranchiseHallOfFameEditModel HallOfFameEditModel
        = new();

    protected PersonModel[] People { get; set; }
        = [];

    private string _search;

    private void Add()
    {
        if (HallOfFameEditModel.FranchiseId == 0)
            return;

        EditModel.HallOfFames.Add(HallOfFameEditModel);

        HallOfFameEditModel = new();
    }

    private void Edit(FranchiseHallOfFameEditModel hallOfFame)
    {
        HallOfFameEditModel.Person = hallOfFame.Person;
        HallOfFameEditModel.Year = EditModel.Value;

        EditMode = EditModeType.Update;
    }

    private async Task Load()
    {
        if (EditModel.FranchiseId == 0)
            return;

        FranchiseHallOfFamesViewModel viewModel = await Mediator.Send(new GetFranchiseHallOfFamers(EditModel.FranchiseId));

        EditModel = new FranchiseHallOfFamesEditModel(viewModel.FranchiseId, viewModel.HallOfFamers);

        var sport = Franchise.GetSport(viewModel.FranchiseId);

        Entity.Person[] people
            = await Mediator.Send(new GetPeople(SportId: sport.Id));

        People = people.Select(person => new PersonModel(person)).ToArray();
    }

    private async Task OnFranchiseHallOfTypeChanged(FranchiseHallOfFameType franchiseHallOfFameType)
    {
        EditModel.FranchiseId = franchiseHallOfFameType.Franchise.Id;

        await Load();
    }

    private async Task OnSave()
    {
        await Mediator.Send(new SaveFranchiseHallOfFamers.Command(EditModel));

        Snackbar.Add("Franchise Hall of Famers were saved successfully!", Severity.Success);

        await Load();
    }    

    private void Update()
    {
        FranchiseHallOfFameEditModel hallOfFame
            = EditModel.HallOfFames.SingleOrDefault(hof => hof.FranchiseId == HallOfFameEditModel.FranchiseId);

        if (hallOfFame is not null)
        {
            hallOfFame.Person = HallOfFameEditModel.Person;
            hallOfFame.Year = HallOfFameEditModel.Year;
        }

        HallOfFameEditModel = new();

        EditMode = EditModeType.Add;
    }
}
