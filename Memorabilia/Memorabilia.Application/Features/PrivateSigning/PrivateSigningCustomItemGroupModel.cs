namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningCustomItemGroupModel
{
    private readonly Entity.PrivateSigningCustomItemGroup _privateSigningCustomItemGroup;

    public PrivateSigningCustomItemGroupModel() { }

    public PrivateSigningCustomItemGroupModel(string name, List<PrivateSigningCustomItemTypeGroupModel> items) 
    {
        Items = items;
        Name = name;
    }

    public PrivateSigningCustomItemGroupModel(Entity.PrivateSigningCustomItemGroup privateSigningCustomItemGroup)
    {
        _privateSigningCustomItemGroup = privateSigningCustomItemGroup;

        Name = _privateSigningCustomItemGroup.Name;
    }

    public UserModel CreatedByUser
        => new(_privateSigningCustomItemGroup.CreatedByUser);

    public DateTime CreatedDate
        => _privateSigningCustomItemGroup.CreatedDate;

    public int Id
        => _privateSigningCustomItemGroup.Id;

    public List<PrivateSigningCustomItemTypeGroupModel> Items { get; set; }
        = [];

    public string Name { get; set; }
}
