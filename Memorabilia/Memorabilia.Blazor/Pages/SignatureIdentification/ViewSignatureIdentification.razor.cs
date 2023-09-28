namespace Memorabilia.Blazor.Pages.SignatureIdentification;

public partial class ViewSignatureIdentification
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

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
       => EditModel.ValidationResult.Errors?.Any() ?? false
           ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
           : Array.Empty<Alert>();

    protected override async Task OnInitializedAsync()
    {
        SignatureIdentificationId = DataProtectorService.DecryptId(EncryptSignatureIdentificationId);

        Model = new(await QueryRouter.Send(new GetSignatureIdentification(SignatureIdentificationId)));

        SignatureIdentificationPersonModel person
            = Model.People.FirstOrDefault(person => person.CreatedUserId == ApplicationStateService.CurrentUser.Id);

        EditModel = person != null
            ? new(person.CreatedUserId,
                  person.Note,
                  person.Person,
                  SignatureIdentificationId)
            : new(ApplicationStateService.CurrentUser.Id, SignatureIdentificationId);
    }

    protected async Task OnSave()
    {
        var command = new SaveSignatureIdentificationPerson.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Snackbar.Add("Signature Identification Person was added successfully!", Severity.Success);

        NavigationManager.NavigateTo(NavigationPath.SignatureIdentification);
    }
}
