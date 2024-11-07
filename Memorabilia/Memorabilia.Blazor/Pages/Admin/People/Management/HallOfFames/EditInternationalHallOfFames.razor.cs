namespace Memorabilia.Blazor.Pages.Admin.People.Management.HallOfFames;

public partial class EditInternationalHallOfFames
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }    

    protected EditModeType EditMode
        = EditModeType.Add;

    private InternationalHallOfFamesEditModel EditModel
        = new();

    private InternationalHallOfFameEditModel HallOfFameEditModel
        = new();

    protected bool HallOfFameTypeIsSelected
        => EditModel.InternationalHallOfFameTypeId > 0;

    protected PersonModel[] People { get; set; }
        = [];

    private string _search;

    private void Add()
    {
        if (HallOfFameEditModel.InternationalHallOfFameTypeId == 0)
            return;

        EditModel.HallOfFames.Add(HallOfFameEditModel);

        HallOfFameEditModel = new();
    }

    private void Edit(InternationalHallOfFameEditModel hallOfFame)
    {
        HallOfFameEditModel.Person = hallOfFame.Person;
        HallOfFameEditModel.Year = EditModel.Value;

        EditMode = EditModeType.Update;
    }

    private async Task Load()
    {
        if (EditModel.InternationalHallOfFameTypeId == 0)
            return;

        InternationalHallOfFamesViewModel viewModel = await Mediator.Send(new GetInternationalHallOfFamers(EditModel.InternationalHallOfFameTypeId));

        EditModel = new InternationalHallOfFamesEditModel(viewModel.InternationalHallOfFameTypeId, viewModel.HallOfFamers);

        Entity.Person[] people
            = await Mediator.Send(new GetPeople());

        People = people.Select(person => new PersonModel(person)).ToArray();
    }

    private async Task OnInternationalHallOfFameTypeChanged(int internationalHallOfFameTypeId)
    {
        EditModel.InternationalHallOfFameTypeId = internationalHallOfFameTypeId;

        await Load();
    }

    private async Task OnSave()
    {
        await Mediator.Send(new SaveInternationalHallOfFamers.Command(EditModel));

        Snackbar.Add("International Hall of Famers were saved successfully!", Severity.Success);

        await Load();
    }

    private void Update()
    {
        InternationalHallOfFameEditModel hallOfFame
            = EditModel.HallOfFames.SingleOrDefault(hof => hof.InternationalHallOfFameTypeId == HallOfFameEditModel.InternationalHallOfFameTypeId);

        if (hallOfFame is not null)
        {
            hallOfFame.Person = HallOfFameEditModel.Person;
            hallOfFame.Year = HallOfFameEditModel.Year;
        }

        HallOfFameEditModel = new();

        EditMode = EditModeType.Add;
    }
}
