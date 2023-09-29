namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPersonExcludeItemTypeEditModel : EditModel
{
	public PrivateSigningPersonExcludeItemTypeEditModel() { }

	public PrivateSigningPersonExcludeItemTypeEditModel(Entity.PrivateSigningPersonExcludeItemType privateSigningPersonExcludeItemType)
	{
		Id = privateSigningPersonExcludeItemType.Id;
		ItemTypeId = privateSigningPersonExcludeItemType.ItemTypeId;
		Note = privateSigningPersonExcludeItemType.Note;
		PrivateSigningPersonId = privateSigningPersonExcludeItemType.PrivateSigningPersonId;
	}

	public int ItemTypeId { get; set; }

	public string Note { get; set; }

	public int PrivateSigningPersonId { get; set; }
}
