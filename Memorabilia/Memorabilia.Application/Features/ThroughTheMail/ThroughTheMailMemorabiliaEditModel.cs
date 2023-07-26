namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailMemorabiliaEditModel : EditModel
{
	public ThroughTheMailMemorabiliaEditModel() { }

	public ThroughTheMailMemorabiliaEditModel(Entity.ThroughTheMailMemorabilia throughTheMailMemorabilia)
	{
		Cost = throughTheMailMemorabilia.Cost;
		Id = throughTheMailMemorabilia.Id;
		MemorabiliaId = throughTheMailMemorabilia.MemorabiliaId;
		ThroughTheMailId = throughTheMailMemorabilia.ThroughTheMailId;
	}

	public decimal? Cost { get; set; }

	public int MemorabiliaId { get; set; }

	public int ThroughTheMailId { get; set; }
}
