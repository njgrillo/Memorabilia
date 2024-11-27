namespace Memorabilia.Application.Features.PrivateSigning.Promoter.CustomItemGroups;

public class CustomItemTypeGroupEditModel : EditModel
{
    public CustomItemTypeGroupEditModel() { }

    public CustomItemTypeGroupEditModel(Entity.PrivateSigningCustomItemTypeGroup privateSigningCustomItemTypeGroup)
    {
        Id = privateSigningCustomItemTypeGroup.Id;
        ItemType = Constant.ItemType.Find(privateSigningCustomItemTypeGroup.ItemTypeId);
        PrivateSigningCustomItemGroupId = privateSigningCustomItemTypeGroup.PrivateSigningCustomItemGroupId;
    }

    public CustomItemTypeGroupEditModel(
        int itemTypeId, 
        int? privateSigningCustomItemGroupId = null
        )
    {
        ItemType = Constant.ItemType.Find(itemTypeId);
        PrivateSigningCustomItemGroupId = privateSigningCustomItemGroupId ?? 0;
    }

    public Constant.ItemType ItemType { get; set; }

    public int PrivateSigningCustomItemGroupId { get; set; }
}
