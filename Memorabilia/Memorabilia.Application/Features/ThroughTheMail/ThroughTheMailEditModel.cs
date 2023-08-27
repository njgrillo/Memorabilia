namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailEditModel : EditModel
{
	public ThroughTheMailEditModel() { }

	public ThroughTheMailEditModel(Entity.ThroughTheMail throughTheMail)
	{
		AddressId = throughTheMail.AddressId;
		Id = throughTheMail.Id;
        Notes = throughTheMail.Notes;
        Person = new PersonEditModel(new PersonModel(throughTheMail.Person));
		ReceivedDate = throughTheMail.ReceivedDate;
		SentDate = throughTheMail.SentDate;
        ThroughTheMailFailureType = Constant.ThroughTheMailFailureType.Find(throughTheMail.ThroughTheMailFailureTypeId ?? 0);
        UserId = throughTheMail.UserId;

		if (!throughTheMail.Memorabilia.Any())
			return;

		Memorabilia = throughTheMail.Memorabilia
								    .Select(memorabilia => new ThroughTheMailMemorabiliaEditModel(memorabilia, throughTheMail))
									.ToList();
	}

    public ThroughTheMailEditModel(ThroughTheMailModel model)
    {
        //AddressId = model.Address?.Id;
        Id = model.Id;
        Notes = model.Notes;
        Person = new PersonEditModel(new PersonModel(model.Person));
        ReceivedDate = model.ReceivedDate;
        SentDate = model.SentDate;
        ThroughTheMailFailureType = Constant.ThroughTheMailFailureType.Find(model.ThroughTheMailFailureTypeId ?? 0);
        UserId = model.UserId;

        if (!model.Memorabilia.Any())
            return;

        Memorabilia = model.Memorabilia
                           .Select(memorabilia => new ThroughTheMailMemorabiliaEditModel(memorabilia, model))
                           .ToList();
    }

    public int? AddressId { get; set; }

	public List<ThroughTheMailMemorabiliaEditModel> Memorabilia { get; set; }
		= new();

    public string Notes { get; set; }

    public PersonEditModel Person { get; set; }
        = new();

    public DateTime? ReceivedDate { get; set; }

	public DateTime? SentDate { get; set; }

    public Constant.ThroughTheMailFailureType ThroughTheMailFailureType { get; set; }

    public int? ThroughTheMailFailureTypeId 
        => ThroughTheMailFailureType?.Id;

	public int UserId { get; set; }
}
