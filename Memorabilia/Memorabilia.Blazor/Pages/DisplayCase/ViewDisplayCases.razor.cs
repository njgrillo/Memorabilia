namespace Memorabilia.Blazor.Pages.DisplayCase;

public partial class ViewDisplayCases
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected List<DisplayCaseModel> Model
        = [];

    protected override async Task OnInitializedAsync()
    {
        Entity.DisplayCase[] displayCases
            = await Mediator.Send(new GetDisplayCases());

        Model = displayCases.Select(DisplayCase => new DisplayCaseModel(DisplayCase)).ToList();
    }

    protected async Task Delete(int id)
    {
        DisplayCaseModel deletedItem
            = Model.Single(displayCase => displayCase.Id == id);

        var model = new DisplayCaseEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveDisplayCase.Command(model));

        Model.Remove(deletedItem);

        Snackbar.Add("Display Case was deleted successfully!", Severity.Success);
    }
}
