namespace Memorabilia.Blazor.Pages.Offer;

public partial class OfferEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public EmailService EmailService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public OfferValidator Validator { get; set; }

    [Parameter]
    public string EncryptMemorabiliaId { get; set; }

    [Parameter]
    public string EncryptOfferId { get; set; }    

    protected OfferEditModel EditModel
        = new();

    protected bool IsReadOnly
        => IsReviewMode &&
           EditModel.OfferStatusTypeId == OfferStatusType.Pending.Id &&
           ApplicationStateService.CurrentUser.Id == EditModel.BuyerId;

    protected bool IsReviewMode
        => !EncryptOfferId.IsNullOrEmpty();

    protected int MemorabiliaId { get; set; }

    protected int OfferId { get; set; }

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.Errors?.Any() ?? false
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : Array.Empty<Alert>();

    protected override async Task OnInitializedAsync()
    {
        if (!IsReviewMode)
        {
            MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

            Entity.Memorabilia memorabilia
                = await Mediator.Send(new GetOfferMemorabilia(MemorabiliaId));

            Entity.User sellerUser
                = await Mediator.Send(new GetUserById(memorabilia.UserId));

            EditModel = new(ApplicationStateService.CurrentUser, sellerUser, memorabilia);
        }
        else
        {
            OfferId = DataProtectorService.DecryptId(EncryptOfferId);

            Entity.Offer offer
                = await Mediator.Send(new GetOffer(OfferId));

            EditModel = new(offer, ApplicationStateService.CurrentUser.Id);
        }
    }

    protected async Task OnAccept()
    {
        await UpdateOfferStatus(OfferStatusType.Accepted);
    }

    protected async Task OnCancel()
    {
        await UpdateOfferStatus(OfferStatusType.Canceled);
    }

    protected async Task OnCounter()
    {
        await UpdateOfferStatus(OfferStatusType.Countered);
    }

    protected async Task OnReject()
    {
        await UpdateOfferStatus(OfferStatusType.Rejected);
    }

    protected async Task OnSend()
    {
        var command = new SaveOffer.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Offer sent!", Severity.Success);

        NavigationManager.NavigateTo(NavigationPath.Offers);

        string body
            = EmailBody.OfferSent
                       .Replace("[[userName]]", EditModel.UserName);

        EmailService.SendEmailMessage(EditModel.OfferPartnerName,
                                      EditModel.OfferPartnerEmail,
                                      EmailSubject.OfferSent,
                                      body);
    }

    private async Task UpdateOfferStatus(OfferStatusType offerStatusType)
    {
        EditModel.OfferStatusTypeId = offerStatusType.Id;

        await Mediator.Send(new SaveOffer.Command(EditModel));

        string subject
            = EmailSubject.Offer
                          .Replace("[[offerStatusType]]", offerStatusType.Name);

        string body
            = EmailBody.Offer
                       .Replace("[[partnerName]]", EditModel.OfferPartnerName)
                       .Replace("[[offerStatusType]]", offerStatusType.Name);

        EmailService.SendEmailMessage(EditModel.OfferPartnerName,
                                      EditModel.OfferPartnerEmail,
                                      subject,
                                      body);

        Snackbar.Add($"Offer has been {offerStatusType.Name}!", Severity.Success);

        string navigationPath
            = offerStatusType == OfferStatusType.Accepted
                ? NavigationPath.Home
                : NavigationPath.Offers;

        NavigationManager.NavigateTo(navigationPath);
    }
}
