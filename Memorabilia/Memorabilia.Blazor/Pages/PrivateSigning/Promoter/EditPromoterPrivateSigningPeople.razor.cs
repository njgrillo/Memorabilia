using Memorabilia.Application.Services.Interfaces;

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
    public ILogger<EditPromoterPrivateSigningPeople> Logger { get; set; }

    [Parameter]
    public List<PrivateSigningPersonEditModel> People { get; set; }
        = [];

    [Parameter]
    public EventCallback PeopleModified { get; set; }

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

        People.Add(EditModel);

        EditModel = new();

        await PeopleModified.InvokeAsync();
    }

    protected void Edit(PrivateSigningPersonEditModel editModel)
    {
        EditModel.Person = editModel.Person;
        EditModel.AllowInscriptions = editModel.AllowInscriptions;
        EditModel.InscriptionCost = editModel.InscriptionCost;
        EditModel.Note = editModel.Note;

        EditMode = EditModeType.Update;
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
            = People.Single(person => person.Person.Id == EditModel.Person.Id);

        editModel.AllowInscriptions = EditModel.AllowInscriptions;
        editModel.InscriptionCost = EditModel.InscriptionCost;
        editModel.Note = EditModel.Note;

        EditModel = new();

        EditMode = EditModeType.Add;
    }
}
