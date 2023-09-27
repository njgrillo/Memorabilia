namespace Memorabilia.Application.Features.User.Settings;

public class UserPaymentOptionEditModel : EditModel
{
	public UserPaymentOptionEditModel() { }

	public UserPaymentOptionEditModel(Entity.UserPaymentOption userPaymentOption)
	{
		Id = userPaymentOption.Id;
        IsPrimary = userPaymentOption.IsPrimary;
        PaymentHandle = userPaymentOption.PaymentHandle;
        PaymentOption = Constant.PaymentOption.Find(userPaymentOption.PaymentOptionId);

		PaymentOptionType = userPaymentOption.IsPrimary 
			? Enum.PaymentOptionType.Primary 
			: Enum.PaymentOptionType.Secondary;
	}

	public bool IsPrimary { get; set; }

	public string PaymentHandle { get; set; }

	public Constant.PaymentOption PaymentOption { get; set; }

	public string PaymentOptionName
		=> PaymentOption?.Name;

	public Enum.PaymentOptionType PaymentOptionType { get; set; }
		= Enum.PaymentOptionType.Primary;

    public string PaymentOptionTypeName
        => PaymentOptionType == Enum.PaymentOptionType.Primary
			? "Primary"
			: "Secondary";
}
