namespace Memorabilia.Application.Features.PrivateSigning.Promoter.CustomItemGroups;

public class CustomItemGroupEditModel : EditModel
{
    public CustomItemGroupEditModel() { }

    public CustomItemGroupEditModel(Entity.PrivateSigningCustomItemGroup privateSigningCustomItemGroup)
    {
        CreatedDate = privateSigningCustomItemGroup.CreatedDate;
        Id = privateSigningCustomItemGroup.Id;
        Items = privateSigningCustomItemGroup.Items.Select(x => new CustomItemTypeGroupEditModel(x)).ToList();
        ItemTypeIds = Items.Select(x => x.ItemType.Id);
        Name = privateSigningCustomItemGroup.Name;
    }

    public CustomItemGroupEditModel(
        string name, 
        List<CustomItemTypeGroupEditModel> items
        )
    {
        CreatedDate = DateTime.Now;
        Items = items;
        ItemTypeIds = Items.Select(x => x.ItemType.Id);
        Name = name;
    }

    public DateTime CreatedDate { get; set; }

    public List<CustomItemTypeGroupEditModel> Items { get; set; }
        = [];

    public IEnumerable<int> ItemTypeIds { get; set; }
}
