namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailMemorabiliaEditModel : EditModel
{
	public ThroughTheMailMemorabiliaEditModel() { }

	public ThroughTheMailMemorabiliaEditModel(Entity.ThroughTheMailMemorabilia throughTheMailMemorabilia, 
		Entity.ThroughTheMail throughTheMail)
	{
		Autograph = throughTheMailMemorabilia.Autograph;
		AutographId = throughTheMailMemorabilia.AutographId;
		Cost = throughTheMailMemorabilia.Cost;
		Id = throughTheMailMemorabilia.Id;
		IsExtraReceived = throughTheMailMemorabilia.IsExtraReceived;
		ItemTypeName = throughTheMailMemorabilia.Memorabilia.ItemType.Name;
		Memorabilia = throughTheMailMemorabilia.Memorabilia;
		MemorabiliaId = throughTheMailMemorabilia.MemorabiliaId;
		PersonId = throughTheMail.PersonId;
		ReceivedDate = throughTheMail.ReceivedDate;
		ThroughTheMailId = throughTheMailMemorabilia.ThroughTheMailId;
	}

    public ThroughTheMailMemorabiliaEditModel(Entity.ThroughTheMailMemorabilia throughTheMailMemorabilia, 
		ThroughTheMailModel throughTheMailModel)
    {
        Autograph = throughTheMailMemorabilia.Autograph;
        AutographId = throughTheMailMemorabilia.AutographId;
        Cost = throughTheMailMemorabilia.Cost;
        Id = throughTheMailMemorabilia.Id;
        IsExtraReceived = throughTheMailMemorabilia.IsExtraReceived;
        ItemTypeName = throughTheMailMemorabilia.Memorabilia.ItemType.Name;
        Memorabilia = throughTheMailMemorabilia.Memorabilia;
        MemorabiliaId = throughTheMailMemorabilia.MemorabiliaId;
        PersonId = throughTheMailModel.Person.Id;
        ReceivedDate = throughTheMailModel.ReceivedDate;
        ThroughTheMailId = throughTheMailMemorabilia.ThroughTheMailId;
    }

    public Entity.Autograph Autograph { get; private set; }

	public int? AutographId { get; set; }

	public string AutographImageFileName { get; set; }

    public decimal? Cost { get; set; }

	public bool IsExtraReceived { get; set; }

	public bool IsSelected { get; set; }

	public string ItemTypeName { get; set; }

	public Entity.Memorabilia Memorabilia { get; private set; }

	public int MemorabiliaId { get; set; }

	public string MemorabiliaImageFileName { get; set; }

	public int PersonId { get; set; }

    public string PrimaryImageFileName
		=> AutographImageFileName
			?? MemorabiliaImageFileName
			?? Memorabilia?.Images?
						   .FirstOrDefault(image => image.ImageTypeId == Constant.ImageType.Primary.Id)?
						   .FileName;

	public DateTime? ReceivedDate { get; set; }

    public int ThroughTheMailId { get; set; }
}
