namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter.PaymentOptions;

public partial class EditPromoterPaymentOptions
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public PromoterPaymentOptionsValidator Validator { get; set; }

    private PromoterPaymentOptionEditModel _elementBeforeEdit;

    protected PromoterPaymentOptionsEditModel EditModel { get; set; }
        = new();

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.HasErrors()
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : [];

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (EditModel.ValidationResult.IsValid)
            return;

        await JSRuntime.ScrollToAlert();
    }

    protected override async Task OnInitializedAsync()
    {
        EditModel = new(await Mediator.Send(new GetPromoterPaymentOptions()), ApplicationStateService.CurrentUser.Id);
    }

    private void AddPaymentOption()
    {
        EditModel.PaymentOptions.Add(new());
    }

    private void BackupItem(object element)
    {
        _elementBeforeEdit = new()
        {
            PaymentMethodHandle = ((PromoterPaymentOptionEditModel)element).PaymentMethodHandle,
            PrivateSigningPaymentMethodId = ((PromoterPaymentOptionEditModel)element).PrivateSigningPaymentMethodId,
        };
    }

    private async void OnSave()
    {
        var command = new SavePromoterPaymentOptions.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Payment Options were saved successfully!", Severity.Success);
    }

    private void ResetItemToOriginalValues(object element)
    {
        ((PromoterPaymentOptionEditModel)element).PaymentMethodHandle = _elementBeforeEdit.PaymentMethodHandle;
        ((PromoterPaymentOptionEditModel)element).PrivateSigningPaymentMethodId = _elementBeforeEdit.PrivateSigningPaymentMethodId;
    }
}
