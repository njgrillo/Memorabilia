namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningCustomItemTypeGroupEditModel : EditModel
{
	public PrivateSigningCustomItemTypeGroupEditModel() { }

	public PrivateSigningCustomItemTypeGroupEditModel(Entity.PrivateSigningCustomItemTypeGroup privateSigningCustomItemTypeGroup)
	{
		Id = privateSigningCustomItemTypeGroup.Id;
		ItemTypeId = privateSigningCustomItemTypeGroup.ItemTypeId;
		PrivateSigningCustomItemGroupId = privateSigningCustomItemTypeGroup.PrivateSigningCustomItemGroupId;
    }

	public int ItemTypeId { get; set; }

	public int PrivateSigningCustomItemGroupId { get; set; }
}
