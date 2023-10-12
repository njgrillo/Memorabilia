namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningCustomItemTypeGroupDetailEditModel : EditModel
{
	public PrivateSigningCustomItemTypeGroupDetailEditModel() { }

	public PrivateSigningCustomItemTypeGroupDetailEditModel(Entity.PrivateSigningCustomItemTypeGroupDetail privateSigningCustomItemTypeGroupDetail)
	{
		Cost = privateSigningCustomItemTypeGroupDetail.Cost;
		PrivateSigningCustomItemGroup = privateSigningCustomItemTypeGroupDetail.PrivateSigningCustomItemGroup;
        PrivateSigningCustomItemTypeGroupId = privateSigningCustomItemTypeGroupDetail.PrivateSigningCustomItemTypeGroupId;
		ShippingCost = privateSigningCustomItemTypeGroupDetail.ShippingCost;
    }

	public decimal Cost { get; set; }

	public Entity.PrivateSigningCustomItemGroup PrivateSigningCustomItemGroup { get; set; }

	public int PrivateSigningCustomItemTypeGroupId { get; set; }

	public decimal? ShippingCost { get; set; }
}
