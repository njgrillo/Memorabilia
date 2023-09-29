namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningCustomItemTypeGroupModel
{
    private readonly Entity.PrivateSigningCustomItemTypeGroup _privateSigningCustomItemTypeGroup;

    public PrivateSigningCustomItemTypeGroupModel() { }

    public PrivateSigningCustomItemTypeGroupModel(Entity.PrivateSigningCustomItemTypeGroup privateSigningCustomItemTypeGroup)
    {
        _privateSigningCustomItemTypeGroup = privateSigningCustomItemTypeGroup;
    }

    public int Id
        => _privateSigningCustomItemTypeGroup.Id;

    public Constant.ItemType ItemType
        => Constant.ItemType.Find(_privateSigningCustomItemTypeGroup.ItemTypeId);

    public int PrivateSigningCustomItemGroupId
        => _privateSigningCustomItemTypeGroup.PrivateSigningCustomItemGroupId;
}
