namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class EditPromoterPrivateSigningPeople
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public ILogger<EditPromoterPrivateSigningPeople> Logger { get; set; }

    [Parameter]
    public EventCallback PeopleModified { get; set; }

    [Parameter]
    public PrivateSigningEditModel PrivateSigning { get; set; }

    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningPersonEditModel EditModel { get; set; }
        = new();

    protected bool LimitSpots { get; set; }

    public ImageEditModel PromoterPrivateSigningPersonImage { get; set; }
        = new();

    protected async Task Add()
    {
        if (EditModel.Person == null || EditModel.Person.Id == 0)
            return;

        if (PrivateSigning.People.Select(x => x.PersonId).Contains(EditModel.Person.Id))
        {
            var options = new DialogOptions()
            {
                MaxWidth = MaxWidth.Medium,
                DisableBackdropClick = true
            };

            var dialog = DialogService.Show<OkDialog>("Unable to add duplicate person.", options);

            await dialog.Result;

            return;
        }

        if (!PrivateSigning.MultiDaySigning)
            EditModel.SigningDate = PrivateSigning.BeginSigningDate;

        PrivateSigning.People.Add(EditModel);

        EditModel = new();

        LimitSpots = false;

        await PeopleModified.InvokeAsync();
    }

    protected async void Edit(PrivateSigningPersonEditModel editModel)
    {
        EditModel.Person = editModel.Person;
        EditModel.SigningDate = editModel.SigningDate;
        EditModel.AllowInscriptions = editModel.AllowInscriptions;
        EditModel.InscriptionCost = editModel.InscriptionCost;
        EditModel.Note = editModel.Note;
        EditModel.PromoterImageFileName = editModel.PromoterImageFileName;

        EditMode = EditModeType.Update;

        await JSRuntime.ScrollToTop();
    }

    protected async Task LoadFile(InputFileChangeEventArgs e)
    {
        try
        {
            EditModel.PromoterImageFileName
                = await ImageService.LoadFile(e.File, Enum.ImageRootType.User);

            PromoterPrivateSigningPersonImage
                = new ImageEditModel(new ImageModel(new Entity.Image(EditModel.PromoterImageFileName)));
        }
        catch (Exception ex)
        {
            Logger.LogError("File: {Filename} Error: {Error}", e.File.Name, ex.Message);
        }
    }

    protected void OnAllowInscriptionsChange(bool allowInscriptions)
    {
        EditModel.AllowInscriptions = allowInscriptions;

        if (allowInscriptions)
            return;

        EditModel.InscriptionCost = null;
    }

    protected void OnLimitSpotsChange(bool limitSpots)
    {
        LimitSpots = limitSpots;

        if (LimitSpots)
            return;

        EditModel.SpotsAvailable = null;
        EditModel.SpotsConfirmed = null;
    }

    protected async Task OnPromotionalImageClick(string imageFileName)
    {
        var parameters = new DialogParameters
        {
            ["ImageFileName"] = imageFileName,
            ["UserId"] = ApplicationStateService.CurrentUser.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ImageDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }

    protected void RemovePromoterPersonImage()
    {
        EditModel.PromoterImageFileName = null;
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
        
        await dialog.Result;
    }

    protected void Update()
    {
        PrivateSigningPersonEditModel editModel
            = PrivateSigning.People.Single(person => person.Person.Id == EditModel.Person.Id);

        editModel.SigningDate = EditModel.SigningDate;
        editModel.AllowInscriptions = EditModel.AllowInscriptions;
        editModel.InscriptionCost = EditModel.InscriptionCost;
        editModel.Note = EditModel.Note;
        editModel.PromoterImageFileName = EditModel.PromoterImageFileName;

        EditModel = new();

        EditMode = EditModeType.Add;
    }
}
