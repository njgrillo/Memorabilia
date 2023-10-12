namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningItemTypeGroupModel
{
    private readonly Entity.PrivateSigningItemTypeGroup _privateSigningItemTypeGroup;

    public PrivateSigningItemTypeGroupModel() { }

    public PrivateSigningItemTypeGroupModel(Entity.PrivateSigningItemTypeGroup privateSigningItemTypeGroup)
    {
        _privateSigningItemTypeGroup = privateSigningItemTypeGroup;
    }

    public decimal Cost 
        => _privateSigningItemTypeGroup.Cost;

    public int Id
        => _privateSigningItemTypeGroup.Id;

    public string ItemGroupName
        => Constant.PrivateSigningItemGroup.Find(_privateSigningItemTypeGroup.PrivateSigningItemGroupId)?.Name;

    public int PrivateSigningItemGroupId
        => _privateSigningItemTypeGroup.PrivateSigningItemGroupId;

    public decimal? ShippingCost
        => _privateSigningItemTypeGroup.ShippingCost;
}
