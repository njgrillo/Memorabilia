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

    public PrivateSigningCustomItemGroupEditModel(
		int id, 
		string name, 
		List<PrivateSigningCustomItemTypeGroupEditModel> items
		)
    {
		Id = id;
		Items = items;
		Name = name;
    }

    public int CreatedByUserId { get; set; }

	public DateTime CreatedDate { get; set; }

	public List<PrivateSigningCustomItemTypeGroupEditModel> Items { get; set; }
		= [];

	public IEnumerable<int> ItemTypeIds { get; set; }
		= [];
}
