namespace Memorabilia.Blazor.Pages.Offer;

public partial class OfferGrid
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public EmailService EmailService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public OfferModel[] Items { get; set; }

    private async Task Accept(OfferModel offerModel)
    {
        await UpdateStatus(offerModel, OfferStatusType.Accepted);
    }

    private async Task Cancel(OfferModel offerModel)
    {
        await UpdateStatus(offerModel, OfferStatusType.Canceled);
    }

    private void Counter(int offerId)
    {
        NavigationManager.NavigateTo($"{NavigationPath.Offer}/Review/{DataProtectorService.EncryptId(offerId)}");
    }

    private async Task Reject(OfferModel offerModel)
    {
        await UpdateStatus(offerModel, OfferStatusType.Rejected);
    }

    private void ToggleChildContent(int offerId)
    {
        OfferModel offer
            = Items.Single(item => item.Id == offerId);

        offer.Memorabilia.DisplayAutographDetails = !offer.Memorabilia.DisplayAutographDetails;

        offer.Memorabilia.ToggleIcon = offer.Memorabilia.DisplayAutographDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }

    private async Task UpdateStatus(OfferModel offerModel,
                                    OfferStatusType offerStatusType)
    {
        OfferEditModel editModel = new(offerModel, ApplicationStateService.CurrentUser.Id)
        {
            OfferStatusTypeId = offerStatusType.Id
        };

        await CommandRouter.Send(new SaveOffer.Command(editModel));

        await Mediator.Publish(new OfferStatusChangedNotification());

        Snackbar.Add($"Offer has been {offerStatusType.Name}!", Severity.Success);

        string subject
            = EmailSubject.Offer
                          .Replace("[[offerStatusType]]", offerStatusType.Name);

        string body
            = EmailBody.Offer
                       .Replace("[[partnerName]]", editModel.OfferPartnerName)
                       .Replace("[[offerStatusType]]", offerStatusType.Name);

        EmailService.SendEmailMessage(editModel.OfferPartnerName,
                                      editModel.OfferPartnerEmail,
                                      subject,
                                      EmailBody.Offer);
    }
}
