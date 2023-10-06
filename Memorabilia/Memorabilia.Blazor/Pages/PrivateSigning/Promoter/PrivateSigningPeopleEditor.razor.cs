namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class PrivateSigningPeopleEditor
{
    [Inject]
    public IDialogService DialogService { get; set; }

    [Parameter]
    public List<PrivateSigningPersonEditModel> People { get; set; }
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningPersonEditModel EditModel { get; set; }
        = new();

    protected void Add()
    {
        if (EditModel.Person == null || EditModel.Person.Id == 0)
            return;

        People.Add(EditModel);

        EditModel = new();
    }

    protected void Edit(PrivateSigningPersonEditModel editModel)
    {
        EditModel.Person = editModel.Person;
        EditModel.AllowInscriptions = editModel.AllowInscriptions;
        EditModel.InscriptionCost = editModel.InscriptionCost;
        EditModel.Note = editModel.Note;

        EditMode = EditModeType.Update;
    }

    protected void OnAllowInscriptionsChange(bool allowInscriptions)
    {
        EditModel.AllowInscriptions = allowInscriptions;

        if (allowInscriptions)
            return;

        EditModel.InscriptionCost = null;
    }

    protected void OnImageLoaded()
    {
        StateHasChanged();
    }

    protected async Task ShowPersonProfile()
    {
        if (EditModel.Person.Id == 0)
            return;

        var parameters = new DialogParameters
        {
            ["PersonId"] = EditModel.Person.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<PersonProfileDialog>(string.Empty, parameters, options);
        var result = await dialog.Result;
    }

    protected void Update()
    {
        PrivateSigningPersonEditModel editModel
            = People.Single(person => person.Person.Id == EditModel.Person.Id);

        editModel.AllowInscriptions = EditModel.AllowInscriptions;
        editModel.InscriptionCost = EditModel.InscriptionCost;
        editModel.Note = EditModel.Note;

        EditModel = new();

        EditMode = EditModeType.Add;
    }
}
