namespace Memorabilia.Domain.Entities;

public class PrivateSigningCustomItemGroup : Entity, IWithName
{
    public PrivateSigningCustomItemGroup() { }

    public PrivateSigningCustomItemGroup(int createdByUserId,
                                         DateTime createdDate,
                                         string name)
    {
        CreatedByUserId = createdByUserId;
        CreatedDate = createdDate;
        Name = name;
    }

    public PrivateSigningCustomItemGroup(
        int createdByUserId,
        string name, 
        PrivateSigningCustomItemTypeGroup[] privateSigningCustomItemTypeGroups)
    {
        CreatedByUserId = createdByUserId;
        CreatedDate = DateTime.UtcNow;
        Items = privateSigningCustomItemTypeGroups.ToList();
        Name = name;
    }

    public PrivateSigningCustomItemGroup(         
        string name,
        int id,
        PrivateSigningCustomItemTypeGroup[] privateSigningCustomItemTypeGroups)
    {
        Id = id;
        Items = privateSigningCustomItemTypeGroups.ToList();
        Name = name;
    }

    public virtual User CreatedByUser { get; private set; }

    public int CreatedByUserId { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public virtual List<PrivateSigningCustomItemTypeGroup> Items { get; private set; }

    public string Name { get; private set; }

    public void RemoveItems(int[] privateSigningCustomItemTypeGroupIds)
    {
        foreach (PrivateSigningCustomItemTypeGroup item in Items.Where(x => privateSigningCustomItemTypeGroupIds.Contains(x.Id)))
        {
            Items.Remove(item);
        }
    }

    public void Set(
        string name,
        PrivateSigningCustomItemTypeGroup[] privateSigningCustomItemTypeGroups
        )
    {
        Name = name;

        IEnumerable<PrivateSigningCustomItemTypeGroup> removedItems
                = Items.Where(x => !privateSigningCustomItemTypeGroups.Select(x => x.ItemTypeId).Contains(x.ItemTypeId));

        IEnumerable<PrivateSigningCustomItemTypeGroup> addedItems
                = privateSigningCustomItemTypeGroups.Where(x => !Items.Select(x => x.ItemTypeId).Contains(x.ItemTypeId));

        if (removedItems.Any())
        {
            Items.RemoveAll(x => removedItems.Contains(x));
        }

        if (addedItems.Any())
        {
            Items.AddRange(addedItems);
        }
    }
}
