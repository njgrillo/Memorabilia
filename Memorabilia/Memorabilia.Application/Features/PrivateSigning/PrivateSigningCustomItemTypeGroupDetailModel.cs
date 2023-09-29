namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningCustomItemTypeGroupDetailModel
{
    private readonly Entity.PrivateSigningCustomItemTypeGroupDetail _privateSigningCustomItemTypeGroupDetail;

    public PrivateSigningCustomItemTypeGroupDetailModel() { }

    public PrivateSigningCustomItemTypeGroupDetailModel(Entity.PrivateSigningCustomItemTypeGroupDetail privateSigningCustomItemTypeGroupDetail)
    {
        _privateSigningCustomItemTypeGroupDetail = privateSigningCustomItemTypeGroupDetail;
    }

    public decimal Cost
        => _privateSigningCustomItemTypeGroupDetail.Cost;

    public int Id
        => _privateSigningCustomItemTypeGroupDetail.Id;

    public int PrivateSigningCustomItemTypeGroupId
        => _privateSigningCustomItemTypeGroupDetail.PrivateSigningCustomItemTypeGroupId;
}
