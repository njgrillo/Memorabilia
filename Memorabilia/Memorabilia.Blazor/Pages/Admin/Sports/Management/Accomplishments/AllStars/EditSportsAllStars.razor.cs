namespace Memorabilia.Blazor.Pages.Admin.Sports.Management.Accomplishments.AllStars;

public partial class EditSportsAllStars
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public string SportId { get; set; }

    [Parameter]
    public int Year { get; set; }

    protected SportAllStarEditModel AllStarEditModel
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected SportAllStarsEditModel EditModel
        = new();

    protected Sport Sport
        => Sport.Find(SportId);

    private string _search;
    private int _sportId;

    protected override async Task OnInitializedAsync()
    {
        _sportId = DataProtectorService.DecryptId(SportId);

        await Load();
    }

    private void Add()
    {
        if (AllStarEditModel.Person?.Id == 0)
            return;

        EditModel.AllStars.Add(AllStarEditModel);

        AllStarEditModel = new();
    }

    private void Edit(SportAllStarEditModel allStar)
    {
        AllStarEditModel.Id = allStar.Id;
        AllStarEditModel.Person = allStar.Person;

        EditMode = EditModeType.Update;
    }

    private async Task Load()
    {
        if (_sportId == 0)
            return;

        SportAllStarsViewModel viewModel = await Mediator.Send(new GetSportAllStars(_sportId, Year));

        EditModel = new SportAllStarsEditModel(viewModel.AllStars);
    }

    private async Task OnSave()
    {
        await Mediator.Send(new SaveSportAllStars.Command(EditModel));

        Snackbar.Add("All Stars were saved successfully!", Severity.Success);

        await Load();
    }

    private void Update()
    {
        SportAllStarEditModel sportAllStar
            = EditModel.AllStars
                       .SingleOrDefault(allStar => (allStar.Id > 0 && allStar.Id == AllStarEditModel.Id) ||
                                                   allStar.Person.Id == AllStarEditModel.Person.Id);

        if (sportAllStar is not null)
        {
            sportAllStar.Person = AllStarEditModel.Person;
        }

        AllStarEditModel = new();

        EditMode = EditModeType.Add;
    }
}
