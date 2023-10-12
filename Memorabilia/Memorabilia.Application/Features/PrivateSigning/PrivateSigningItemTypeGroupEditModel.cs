namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningItemTypeGroupEditModel : EditModel
{
	public PrivateSigningItemTypeGroupEditModel() { }

	public PrivateSigningItemTypeGroupEditModel(Entity.PrivateSigningItemTypeGroup privateSigningItemTypeGroup)
	{
		Cost = privateSigningItemTypeGroup.Cost;
		Id = privateSigningItemTypeGroup.Id;
        PrivateSigningItemGroupId = privateSigningItemTypeGroup.PrivateSigningItemGroupId;
		ShippingCost = privateSigningItemTypeGroup.ShippingCost;
    }

	public decimal Cost { get; set; }

	public int ItemTypeId { get; set; }

	public int PrivateSigningItemGroupId { get; set; }

	public decimal? ShippingCost { get; set; }
}
