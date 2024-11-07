namespace Memorabilia.Blazor.Pages.Admin.People.Management.HallOfFames;

public partial class EditCollegeHallOfFames
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected bool CollegeIsSelected
        => EditModel.CollegeId > 0;

    protected EditModeType EditMode
        = EditModeType.Add;

    private CollegeHallOfFamesEditModel EditModel
        = new();

    private CollegeHallOfFameEditModel HallOfFameEditModel
        = new();

    protected PersonModel[] People { get; set; }
        = [];

    private string _search;

    private void Add()
    {
        if (HallOfFameEditModel.CollegeId == 0)
            return;

        EditModel.HallOfFames.Add(HallOfFameEditModel);

        HallOfFameEditModel = new();
    }

    private void Edit(CollegeHallOfFameEditModel hallOfFame)
    {
        HallOfFameEditModel.Person = hallOfFame.Person;
        HallOfFameEditModel.SportId = hallOfFame.SportId;
        HallOfFameEditModel.Year = EditModel.Value;

        EditMode = EditModeType.Update;
    }

    private async Task Load()
    {
        if (EditModel.CollegeId == 0)
            return;

        CollegeHallOfFamesViewModel viewModel = await Mediator.Send(new GetCollegeHallOfFamers(EditModel.CollegeId));

        EditModel = new CollegeHallOfFamesEditModel(viewModel.CollegeId, viewModel.HallOfFamers);

        Entity.Person[] people
            = await Mediator.Send(new GetPeople());

        People = people.Select(person => new PersonModel(person)).ToArray();
    }

    private async Task OnCollegeChanged(College college)
    {
        EditModel.CollegeId = college.Id;

        await Load();
    }

    private async Task OnSave()
    {
        await Mediator.Send(new SaveCollegeHallOfFamers.Command(EditModel));

        Snackbar.Add("College Hall of Famers were saved successfully!", Severity.Success);

        await Load();
    }

    private void Update()
    {
        CollegeHallOfFameEditModel hallOfFame
            = EditModel.HallOfFames.SingleOrDefault(hof => hof.CollegeId == HallOfFameEditModel.CollegeId);

        if (hallOfFame is not null)
        {
            hallOfFame.Person = HallOfFameEditModel.Person;
            hallOfFame.SportId = HallOfFameEditModel.SportId;
            hallOfFame.Year = HallOfFameEditModel.Year;
        }

        HallOfFameEditModel = new();

        EditMode = EditModeType.Add;
    }
}
