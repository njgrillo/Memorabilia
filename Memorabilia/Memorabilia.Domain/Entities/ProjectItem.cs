namespace Memorabilia.Domain.Entities;

public class ProjectItem : DomainIdEntity
{
    public ProjectItem() { }

    public ProjectItem(int projectId,
        int itemTypeId,
        bool multiSignedItem)
    {
        ProjectId = projectId;
        ItemTypeId = itemTypeId;
        MultiSignedItem = multiSignedItem;
    }

    public int ItemTypeId { get; set; }

    public bool MultiSignedItem { get; set; }

    public int ProjectId { get; set; }

    public void Set(int itemTypeId, bool multiSignedItem)
    {
        ItemTypeId = itemTypeId;
        MultiSignedItem = multiSignedItem;
    }
}
