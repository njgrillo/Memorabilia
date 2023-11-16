using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.SignatureIdentification;

public partial class ViewSignatureIdentification
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public SignatureIdentificationPersonValidator Validator { get; set; }

    [Parameter]
    public string EncryptSignatureIdentificationId { get; set; }

    protected SignatureIdentificationPersonEditModel EditModel { get; set; }
        = new();

    protected SignatureIdentificationModel Model { get; set; }
        = new();

    protected int SignatureIdentificationId { get; set; }

    protected Alert[] ValidationResultAlerts
       => EditModel.ValidationResult.HasErrors()
           ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
           : [];

    protected override async Task OnInitializedAsync()
    {
        SignatureIdentificationId = DataProtectorService.DecryptId(EncryptSignatureIdentificationId);

        Model = new(await Mediator.Send(new GetSignatureIdentification(SignatureIdentificationId)));

        SignatureIdentificationPersonModel person
            = Model.People.FirstOrDefault(person => person.CreatedUserId == ApplicationStateService.CurrentUser.Id);

        EditModel = person != null
            ? new(person.CreatedUserId,
                  person.Note,
                  person.Person,
                  SignatureIdentificationId)
            : new(ApplicationStateService.CurrentUser.Id, SignatureIdentificationId);
    }

    protected async Task OnImageClick(SignatureIdentificationModel signatureIdentification, int imageId)
    {
        var parameters = new DialogParameters
        {
            ["SelectedImageId"] = imageId,
            ["SignatureIdentificationId"] = signatureIdentification.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Small,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<SignatureIdentificationImageCarouselViewerDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }

    protected async Task OnSave()
    {
        var command = new SaveSignatureIdentificationPerson.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Signature Identification Person was added successfully!", Severity.Success);

        NavigationManager.NavigateTo(NavigationPath.SignatureIdentification);
    }
}
