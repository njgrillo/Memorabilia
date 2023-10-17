namespace Memorabilia.Blazor.Pages.SignatureReview;

public partial class ViewSignatureReview
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public SignatureReviewUserResultValidator Validator { get; set; }

    [Parameter]
    public string EncryptSignatureReviewId { get; set; }

    protected SignatureReviewUserResultEditModel EditModel { get; set; }
        = new();

    protected SignatureReviewModel Model { get; set; }
        = new();

    protected int SignatureReviewId { get; set; }

    protected Alert[] ValidationResultAlerts
       => EditModel.ValidationResult.Errors?.Any() ?? false
           ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
           : Array.Empty<Alert>();

    protected override async Task OnInitializedAsync()
    {
        SignatureReviewId = DataProtectorService.DecryptId(EncryptSignatureReviewId);

        Model = new(await Mediator.Send(new GetSignatureReview(SignatureReviewId)));

        SignatureReviewUserResultModel userResult
            = Model.UserResults.FirstOrDefault(result => result.CreatedUserId == ApplicationStateService.CurrentUser.Id);

        EditModel = userResult != null
            ? new(userResult.CreatedUserId,
                  userResult.Id,
                  userResult.Note,
                  userResult.SignatureReviewId,
                  userResult.SignatureReviewResultTypeId)
            : new(ApplicationStateService.CurrentUser.Id, SignatureReviewId);
    }

    protected async Task OnSave()
    {
        var command = new SaveSignatureReviewUserResult.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Signature Review Result was added successfully!", Severity.Success);

        NavigationManager.NavigateTo(NavigationPath.SignatureReview);
    }
}
