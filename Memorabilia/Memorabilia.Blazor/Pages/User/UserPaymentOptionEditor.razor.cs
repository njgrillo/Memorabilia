namespace Memorabilia.Blazor.Pages.User;

public partial class UserPaymentOptionEditor
{
    [Parameter]
    public List<UserPaymentOptionEditModel> PaymentOptions { get; set; }
        = new();

    protected EditModeType EditMode
        = EditModeType.Add;

    protected UserPaymentOptionEditModel EditModel
        = new();    

    protected override void OnParametersSet()
    {
        if (PaymentOptions.Any(paymentOption => !paymentOption.IsDeleted))
            EditModel.PaymentOptionType = Enum.PaymentOptionType.Secondary;
    }

    private void Add()
    {
        if (EditModel.PaymentOption == null)
            return;

        PaymentOptions.Add(EditModel);

        EditModel = new UserPaymentOptionEditModel
        {
            PaymentOptionType = Enum.PaymentOptionType.Secondary
        };
    }

    private void Delete(UserPaymentOptionEditModel paymentOption)
    {
        paymentOption.IsDeleted = true;

        EditModel.PaymentOptionType = PaymentOptions.Any(paymentOption => !paymentOption.IsDeleted)
            ? Enum.PaymentOptionType.Secondary
            : Enum.PaymentOptionType.Primary;
    }

    private void Edit(UserPaymentOptionEditModel paymentOption)
    {
        EditModel.PaymentHandle = paymentOption.PaymentHandle;
        EditModel.PaymentOption = paymentOption.PaymentOption;
        EditModel.PaymentOptionType = paymentOption.PaymentOptionType;

        EditMode = EditModeType.Update;
    }

    private void OnPaymentOptionTypeChange(bool value)
    {
        EditModel.PaymentOptionType = value
            ? Enum.PaymentOptionType.Primary
            : Enum.PaymentOptionType.Secondary;
    }

    private void Update()
    {
        UserPaymentOptionEditModel paymentOption
            = EditModel.Id > 0
                ? PaymentOptions.Single(option => option.Id == EditModel.Id)
                : PaymentOptions.Single(option => option.PaymentOption.Id == EditModel.PaymentOption.Id);

        paymentOption.PaymentHandle = EditModel.PaymentHandle;
        paymentOption.PaymentOptionType = EditModel.PaymentOptionType;

        EditModel = new();

        EditMode = EditModeType.Add;
    }    
}
