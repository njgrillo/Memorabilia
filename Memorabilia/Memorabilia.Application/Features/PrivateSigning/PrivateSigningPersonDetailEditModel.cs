using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPersonDetailEditModel : EditModel
{
	public PrivateSigningPersonDetailEditModel() { }

	public PrivateSigningPersonDetailEditModel(Entity.PrivateSigningPersonDetail privateSigningPersonDetail)
	{
		Id = privateSigningPersonDetail.Id;
		Note = privateSigningPersonDetail.Note;
		Person = new(privateSigningPersonDetail.PrivateSigningPerson.Person);
        PrivateSigningCustomItemTypeGroupDetail = new(privateSigningPersonDetail.PrivateSigningCustomItemTypeGroupDetail);
        PrivateSigningCustomItemTypeGroupDetailId = privateSigningPersonDetail.PrivateSigningCustomItemTypeGroupDetailId;
		PrivateSigningItemGroup = Constant.PrivateSigningItemGroup.Find(privateSigningPersonDetail.PrivateSigningItemTypeGroupId ?? 0);
		PrivateSigningItemTypeGroupId = privateSigningPersonDetail.PrivateSigningItemTypeGroupId;
		PrivateSigningPersonId = privateSigningPersonDetail.PrivateSigningPersonId;
    }

	public decimal? Cost { get; set; }

	public string Note { get; set; }

    public PrivateSigningCustomItemTypeGroupDetailEditModel PrivateSigningCustomItemTypeGroupDetail { get; set; }
        = new();

    public int? PrivateSigningCustomItemTypeGroupDetailId { get; set; }

	public Constant.PrivateSigningItemGroup PrivateSigningItemGroup { get; set; }	

    public int? PrivateSigningItemTypeGroupId { get; set; }

	public PersonModel Person { get; set; }
		= new();

    public int PrivateSigningPersonId { get; set; }
}
