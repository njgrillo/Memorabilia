namespace Memorabilia.Application.Features.PrivateSigning;

public class PromoterProvidedItemModel
{
	private readonly Entity.PromoterProvidedItem _promoterProvidedItem;

	public PromoterProvidedItemModel() { }

	public PromoterProvidedItemModel(Entity.PromoterProvidedItem promoterProvidedItem)
	{
		_promoterProvidedItem = promoterProvidedItem;
	}

	public decimal Cost
		=> _promoterProvidedItem.Cost;

	public Constant.ItemType ItemType
		=> Constant.ItemType.Find(_promoterProvidedItem?.ItemTypeId ?? 0);

	public UserModel Promoter
		=> _promoterProvidedItem != null
			? new(_promoterProvidedItem.Promoter)
			: new();

	public decimal? ShippingCost
		=> _promoterProvidedItem.ShippingCost;
}
