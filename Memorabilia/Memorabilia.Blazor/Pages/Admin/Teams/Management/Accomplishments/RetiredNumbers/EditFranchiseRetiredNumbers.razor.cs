namespace Memorabilia.Blazor.Pages.Admin.Teams.Management.Accomplishments.RetiredNumbers;

public partial class EditFranchiseRetiredNumbers
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public int FranchiseId { get; set; }

    protected EditModeType EditMode
        = EditModeType.Add;

    private FranchiseRetiredNumbersEditModel EditModel
        = new();    

    protected PersonModel[] People { get; set; }
        = [];

    private FranchiseRetiredNumberEditModel RetiredNumberEditModel
        = new();

    private bool _peopleLoaded;
    private string _search;

    protected override async Task OnInitializedAsync()
    {
        await Load();

        if (_peopleLoaded)
            return;

        Sport sport = Franchise.GetSport(Franchise.Find(FranchiseId)?.Id ?? 0);

        Entity.Person[] people
            = await Mediator.Send(new GetPeople(SportId: sport?.Id));

        People = people.Select(person => new PersonModel(person)).ToArray();

        _peopleLoaded = true;
    }

    private void Add()
    {
        if (RetiredNumberEditModel.Person?.Id == 0 ||
            RetiredNumberEditModel.PlayerNumber.IsNullOrEmpty())
            return;

        EditModel.RetiredNumbers.Add(RetiredNumberEditModel);

        RetiredNumberEditModel = new();
    }

    private void Edit(FranchiseRetiredNumberEditModel retiredNumber)
    {
        RetiredNumberEditModel.Id = retiredNumber.Id;
        RetiredNumberEditModel.Person = retiredNumber.Person;
        RetiredNumberEditModel.PlayerNumber = retiredNumber.PlayerNumber;

        EditMode = EditModeType.Update;
    }

    private async Task Load()
    {
        if (FranchiseId == 0)
            return;

        Entity.Franchise franchise = await Mediator.Send(new GetFranchise(FranchiseId));

        EditModel = new FranchiseRetiredNumbersEditModel(franchise);
    }

    private async Task OnSave()
    {
        await Mediator.Send(new SaveFranchiseRetiredNumbers.Command(EditModel));

        Snackbar.Add("Franchise Retired Numbers were saved successfully!", Severity.Success);

        await Load();
    }

    private void Update()
    {
        FranchiseRetiredNumberEditModel retiredNumber
            = EditModel.RetiredNumbers
                       .SingleOrDefault(number => (number.Id > 0 && number.Id == RetiredNumberEditModel.Id) || 
                                                  number.Person.Id == RetiredNumberEditModel.Person.Id);

        if (retiredNumber is not null)
        {
            retiredNumber.PlayerNumber = RetiredNumberEditModel.PlayerNumber;
        }

        RetiredNumberEditModel = new();

        EditMode = EditModeType.Add;
    }
}
