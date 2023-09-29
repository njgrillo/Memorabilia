namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPersonExcludeItemTypeModel
{
    private readonly Entity.PrivateSigningPersonExcludeItemType _privateSigningPersonExcludeItemType;

    public PrivateSigningPersonExcludeItemTypeModel() { }

    public PrivateSigningPersonExcludeItemTypeModel(Entity.PrivateSigningPersonExcludeItemType privateSigningPersonExcludeItemType)
    {
        _privateSigningPersonExcludeItemType = privateSigningPersonExcludeItemType;
    }

    public int Id
        => _privateSigningPersonExcludeItemType.Id;

    public Constant.ItemType ItemType
        => Constant.ItemType.Find(_privateSigningPersonExcludeItemType.ItemTypeId);

    public string Note
        => _privateSigningPersonExcludeItemType.Note;

    public int PrivateSigningPersonId
        => _privateSigningPersonExcludeItemType.PrivateSigningPersonId;
}
