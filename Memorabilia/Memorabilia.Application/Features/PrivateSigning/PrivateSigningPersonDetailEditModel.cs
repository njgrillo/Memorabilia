namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPersonDetailEditModel : EditModel
{
	public PrivateSigningPersonDetailEditModel() { }

	public PrivateSigningPersonDetailEditModel(Entity.PrivateSigningPersonDetail privateSigningPersonDetail)
	{
		Id = privateSigningPersonDetail.Id;
		Note = privateSigningPersonDetail.Note;
		PrivateSigningCustomItemTypeGroupDetailId = privateSigningPersonDetail.PrivateSigningCustomItemTypeGroupDetailId;
		PrivateSigningItemTypeGroupId = privateSigningPersonDetail.PrivateSigningItemTypeGroupId;
		PrivateSigningPersonId = privateSigningPersonDetail.PrivateSigningPersonId;
    }

	public string Note { get; set; }

    public int? PrivateSigningCustomItemTypeGroupDetailId { get; set; }

    public int? PrivateSigningItemTypeGroupId { get; set; }

	public int PrivateSigningPersonId { get; set; }
}
