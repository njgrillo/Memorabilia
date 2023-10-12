namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningCustomItemGroupEditModel : EditModel
{
	public PrivateSigningCustomItemGroupEditModel() { }

	public PrivateSigningCustomItemGroupEditModel(Entity.PrivateSigningCustomItemGroup privateSigningCustomItemGroup)
	{
		CreatedByUserId = privateSigningCustomItemGroup.CreatedByUserId;
		CreatedDate = privateSigningCustomItemGroup.CreatedDate;
		Id = privateSigningCustomItemGroup.Id;
		Name = privateSigningCustomItemGroup.Name;
    }

	public int CreatedByUserId { get; set; }

	public DateTime CreatedDate { get; set; }

	public List<PrivateSigningCustomItemTypeGroupEditModel> Items { get; set; }
		= new();
}
