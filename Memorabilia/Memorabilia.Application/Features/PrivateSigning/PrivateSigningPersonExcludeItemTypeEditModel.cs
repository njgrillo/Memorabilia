namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPersonExcludeItemTypeEditModel : EditModel
{
	public PrivateSigningPersonExcludeItemTypeEditModel() { }

	public PrivateSigningPersonExcludeItemTypeEditModel(Entity.PrivateSigningPersonExcludeItemType privateSigningPersonExcludeItemType)
	{
		Id = privateSigningPersonExcludeItemType.Id;
		ItemType = Constant.ItemType.Find(privateSigningPersonExcludeItemType.ItemTypeId);
		ItemTypeId = privateSigningPersonExcludeItemType.ItemTypeId;
		Note = privateSigningPersonExcludeItemType.Note;
		Person = new(privateSigningPersonExcludeItemType.PrivateSigningPerson.Person);
		PrivateSigningPersonId = privateSigningPersonExcludeItemType.PrivateSigningPersonId;
	}

	public Constant.ItemType ItemType { get; set; }

	public int ItemTypeId { get; set; }

	public string Note { get; set; }

	public PersonModel Person { get; set; }
		= new();

	public int PrivateSigningPersonId { get; set; }
}
