namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailEditModel : EditModel
{
	public ThroughTheMailEditModel() { }

	public ThroughTheMailEditModel(Entity.ThroughTheMail throughTheMail)
	{
		AddressId = throughTheMail.AddressId;
		Id = throughTheMail.Id;
		PersonId = throughTheMail.PersonId;
		ReceivedDate = throughTheMail.ReceivedDate;
		SentDate = throughTheMail.SentDate;
		UserId = throughTheMail.UserId;

		if (!throughTheMail.Memorabilia.Any())
			return;

		Memorabilia = throughTheMail.Memorabilia
								    .Select(memorabilia => new ThroughTheMailMemorabiliaEditModel(memorabilia))
									.ToList();
	}

    public ThroughTheMailEditModel(ThroughTheMailModel model)
    {
        //AddressId = model.Address?.Id;
        Id = model.Id;
        //PersonId = model.Person?.Id;
        ReceivedDate = model.ReceivedDate;
        SentDate = model.SentDate;
        UserId = model.UserId;

        //if (!model.Memorabilia.Any())
        //    return;

        //Memorabilia = model.Memorabilia
        //                   .Select(memorabilia => new ThroughTheMailMemorabiliaEditModel(memorabilia))
        //                   .ToList();
    }

    public int? AddressId { get; set; }

	public List<ThroughTheMailMemorabiliaEditModel> Memorabilia { get; set; }
		= new();

	public int PersonId { get; set; }

	public DateTime? ReceivedDate { get; set; }

	public DateTime? SentDate { get; set; }

	public int UserId { get; set; }
}
