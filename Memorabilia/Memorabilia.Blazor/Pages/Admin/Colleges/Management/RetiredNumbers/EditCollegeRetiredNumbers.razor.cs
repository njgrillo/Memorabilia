namespace Memorabilia.Blazor.Pages.Admin.Colleges.Management.RetiredNumbers;

public partial class EditCollegeRetiredNumbers
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
    public int CollegeId { get; set; }

    protected EditModeType EditMode
        = EditModeType.Add;

    private CollegeRetiredNumbersEditModel EditModel
        = new();

    protected PersonModel[] People { get; set; }
        = [];

    private CollegeRetiredNumberEditModel RetiredNumberEditModel
        = new();

    private string _search;

    protected override async Task OnInitializedAsync()
    {
        await Load();
    }

    private void Add()
    {
        if (RetiredNumberEditModel.Person?.Id == 0 ||
            RetiredNumberEditModel.PlayerNumber.IsNullOrEmpty())
            return;

        EditModel.RetiredNumbers.Add(RetiredNumberEditModel);

        RetiredNumberEditModel = new();
    }

    private void Edit(CollegeRetiredNumberEditModel retiredNumber)
    {
        RetiredNumberEditModel.Id = retiredNumber.Id;
        RetiredNumberEditModel.Person = retiredNumber.Person;
        RetiredNumberEditModel.PlayerNumber = retiredNumber.PlayerNumber;

        EditMode = EditModeType.Update;
    }

    private async Task Load()
    {
        if (CollegeId == 0)
            return;

        Entity.College College = await Mediator.Send(new GetCollege(CollegeId));

        EditModel = new CollegeRetiredNumbersEditModel(College);
    }

    private async Task OnSave()
    {
        await Mediator.Send(new SaveCollegeRetiredNumbers.Command(EditModel));

        Snackbar.Add("College Retired Numbers were saved successfully!", Severity.Success);

        await Load();
    }

    private void Update()
    {
        CollegeRetiredNumberEditModel retiredNumber
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
