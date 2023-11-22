namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPersonDetailModel
{
    private readonly Entity.PrivateSigningPersonDetail _privateSigningPersonDetail;

    public PrivateSigningPersonDetailModel() { }

    public PrivateSigningPersonDetailModel(Entity.PrivateSigningPersonDetail privateSigningPersonDetail)
    {
        _privateSigningPersonDetail = privateSigningPersonDetail;
    }

    public string Description
        => PrivateSigningItemTypeGroupId.HasValue
            ? $"{PrivateSigningItemTypeGroup.ItemGroupName} - {PrivateSigningItemTypeGroup.Cost:c}"
            : $"{PrivateSigningCustomItemTypeGroupDetail.ItemGroupName} - {PrivateSigningCustomItemTypeGroupDetail.Cost:c}";

    public int Id
        => _privateSigningPersonDetail.Id;

    public string Note
        => _privateSigningPersonDetail.Note;

    public PrivateSigningCustomItemTypeGroupDetailModel PrivateSigningCustomItemTypeGroupDetail
        => new(_privateSigningPersonDetail.PrivateSigningCustomItemTypeGroupDetail);

    public int? PrivateSigningCustomItemTypeGroupDetailId
        => _privateSigningPersonDetail.PrivateSigningCustomItemTypeGroupDetailId;

    public PrivateSigningItemTypeGroupModel PrivateSigningItemTypeGroup
        => new(_privateSigningPersonDetail.PrivateSigningItemTypeGroup);

    public int? PrivateSigningItemTypeGroupId
        => _privateSigningPersonDetail.PrivateSigningItemTypeGroupId;

    public int PrivateSigningPersonId
        => _privateSigningPersonDetail.PrivateSigningPersonId;
}
