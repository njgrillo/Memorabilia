namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningCustomItemGroupModel
{
    private readonly Entity.PrivateSigningCustomItemGroup _privateSigningCustomItemGroup;

    public PrivateSigningCustomItemGroupModel() { }

    public PrivateSigningCustomItemGroupModel(Entity.PrivateSigningCustomItemGroup privateSigningCustomItemGroup)
    {
        _privateSigningCustomItemGroup = privateSigningCustomItemGroup;
    }

    public UserModel CreatedByUser
        => new(_privateSigningCustomItemGroup.CreatedByUser);

    public DateTime CreatedDate
        => _privateSigningCustomItemGroup.CreatedDate;

    public int Id
        => _privateSigningCustomItemGroup.Id;

    public string Name
        => _privateSigningCustomItemGroup.Name;
}
