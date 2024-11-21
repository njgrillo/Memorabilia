namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class EditPromoterPrivateSigningPaymentOption
{   
    protected EditModeType EditMode
        = EditModeType.Add;

    protected PrivateSigningPaymentOptionEditModel EditModel { get; set; }
        = new();

    [Parameter]
    public List<PrivateSigningPaymentOptionEditModel> PaymentOptions { get; set; }
        = [];

    private void Add()
    {
        if (EditModel.PrivateSigningPaymentMethodId == 0)
            return;

        PaymentOptions.Add(EditModel);

        EditModel = new();
    }

    private void Edit(PrivateSigningPaymentOptionEditModel editModel)
    {
        EditModel.PrivateSigningPaymentMethodId = editModel.PrivateSigningPaymentMethodId;
        EditModel.PaymentMethodHandle = editModel.PaymentMethodHandle;

        EditMode = EditModeType.Update;
    }

    private void Update()
    {
        PrivateSigningPaymentOptionEditModel editModel
            = PaymentOptions.Single(option => (option.Id > 0 && option.Id == EditModel.Id) || option.TemporaryId == EditModel.TemporaryId);

        editModel.PrivateSigningPaymentMethodId = EditModel.PrivateSigningPaymentMethodId;
        editModel.PaymentMethodHandle = EditModel.PaymentMethodHandle;

        EditModel = new();

        EditMode = EditModeType.Add;
    }
}
