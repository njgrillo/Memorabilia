namespace Memorabilia.Application.Features.PrivateSigning.Promoter.CustomItemGroups;

public class CustomItemTypeGroupViewModel
{
    private readonly Entity.PrivateSigningCustomItemTypeGroup _privateSigningCustomItemTypeGroup;

    public CustomItemTypeGroupViewModel() { }

    public CustomItemTypeGroupViewModel(Entity.PrivateSigningCustomItemTypeGroup privateSigningCustomItemTypeGroup)
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
