namespace Memorabilia.Application.Features.PrivateSigning;

public class PromoterProvidedItemEditModel : EditModel
{
	public PromoterProvidedItemEditModel() { }

	public PromoterProvidedItemEditModel(Entity.PromoterProvidedItem promoterProvidedItem)
	{
		Cost = promoterProvidedItem.Cost;
		ItemType = Constant.ItemType.Find(promoterProvidedItem.ItemTypeId);
        ItemTypeId = promoterProvidedItem.ItemTypeId;
		Promoter = new(promoterProvidedItem.Promoter);
		PromoterId = promoterProvidedItem.PromoterId;
		ShippingCost = promoterProvidedItem.ShippingCost;
	}

	public decimal? Cost { get; set; }

	public Constant.ItemType ItemType { get; set; }

	public int ItemTypeId { get; set; }

	public UserModel Promoter { get; set; }

    public int PromoterId { get; set; }	

	public decimal? ShippingCost { get; set; }
}
