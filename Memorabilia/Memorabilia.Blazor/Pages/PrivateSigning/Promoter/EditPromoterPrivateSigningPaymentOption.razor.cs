namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class EditPromoterPrivateSigningPaymentOption
{
    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public int PrivateSigningId { get; set; }

    protected EditModeType EditMode
        = EditModeType.Add;

    protected bool DisplayHandle
        => PrivateSigningPaymentMethod.HasHandle(EditModel.PrivateSigningPaymentMethodId);

    protected PrivateSigningPaymentOptionEditModel EditModel { get; set; }
        = new();

    [Parameter]
    public List<PrivateSigningPaymentOptionEditModel> PaymentOptions { get; set; }
        = [];

    private void Add()
    {
        if (EditModel.PrivateSigningPaymentMethodId == 0)
            return;

        if (EditModel.PrivateSigningId == 0)
        {
            EditModel.PrivateSigningId = PrivateSigningId;  
        }

        PaymentOptions.Add(EditModel);

        EditModel = new()
        {
            PrivateSigningId = PrivateSigningId
        };
    }

    private void Edit(PrivateSigningPaymentOptionEditModel editModel)
    {
        EditModel.Id = editModel.Id;
        EditModel.PaymentMethodHandle = editModel.PaymentMethodHandle;
        EditModel.PrivateSigningId = editModel.PrivateSigningId;
        EditModel.PrivateSigningPaymentMethodId = editModel.PrivateSigningPaymentMethodId;        
        EditModel.TemporaryId = editModel.TemporaryId;

        EditMode = EditModeType.Update;
    }

    private async Task ImportPaymentOption()
    {
        Entity.PromoterPaymentOption[] promoterPaymentOptions = await Mediator.Send(new GetPromoterPaymentOptions());

        foreach (Entity.PromoterPaymentOption promoterPaymentOption in promoterPaymentOptions)
        {
            if (PaymentOptions.Any(option => option.PrivateSigningPaymentMethodId == promoterPaymentOption.PrivateSigningPaymentMethodId))
                continue;

            var option =
                new PrivateSigningPaymentOptionEditModel(
                    promoterPaymentOption.PrivateSigningPaymentMethodId, 
                    promoterPaymentOption.PaymentMethodHandle
                    );

            PaymentOptions.Add(option);
        }
    }

    private void Update()
    {
        PrivateSigningPaymentOptionEditModel editModel
            = PaymentOptions.Single(option => (option.Id > 0 && option.Id == EditModel.Id) || option.TemporaryId == EditModel.TemporaryId);

        editModel.PrivateSigningPaymentMethodId = EditModel.PrivateSigningPaymentMethodId;
        editModel.PaymentMethodHandle = EditModel.PaymentMethodHandle;

        EditModel = new()
        {
            PrivateSigningId = PrivateSigningId
        };

        EditMode = EditModeType.Add;
    }
}
