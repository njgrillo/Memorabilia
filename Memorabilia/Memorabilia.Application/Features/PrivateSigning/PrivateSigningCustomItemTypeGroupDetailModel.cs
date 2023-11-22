namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningCustomItemTypeGroupDetailModel
{
    private readonly Entity.PrivateSigningCustomItemTypeGroupDetail _privateSigningCustomItemTypeGroupDetail;

    public PrivateSigningCustomItemTypeGroupDetailModel() { }

    public PrivateSigningCustomItemTypeGroupDetailModel(Entity.PrivateSigningCustomItemTypeGroupDetail privateSigningCustomItemTypeGroupDetail)
    {
        _privateSigningCustomItemTypeGroupDetail = privateSigningCustomItemTypeGroupDetail;
    }

    public decimal Cost
        => _privateSigningCustomItemTypeGroupDetail.Cost;

    public int Id
        => _privateSigningCustomItemTypeGroupDetail.Id;

    public string ItemGroupName
        => _privateSigningCustomItemTypeGroupDetail.PrivateSigningCustomItemGroup.Name;

    public int PrivateSigningCustomItemTypeGroupId
        => _privateSigningCustomItemTypeGroupDetail.PrivateSigningCustomItemTypeGroupId;

    public decimal? ShippingCost
        => _privateSigningCustomItemTypeGroupDetail.ShippingCost;
}
