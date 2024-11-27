namespace Memorabilia.Application.Features.PrivateSigning.Promoter.CustomItemGroups;

public class CustomItemGroupViewModel
{
    private readonly Entity.PrivateSigningCustomItemGroup _privateSigningCustomItemGroup;

    public CustomItemGroupViewModel() {}

    public CustomItemGroupViewModel(Entity.PrivateSigningCustomItemGroup privateSigningCustomItemGroup)
    {
        _privateSigningCustomItemGroup = privateSigningCustomItemGroup;
    }

    public DateTime CreatedDate
        => _privateSigningCustomItemGroup.CreatedDate;

    public List<CustomItemTypeGroupEditModel> Items 
        => _privateSigningCustomItemGroup.Items
                                         .Select(x => new CustomItemTypeGroupEditModel(x))
                                         .ToList();   

    public string Name 
        => _privateSigningCustomItemGroup.Name;
}
