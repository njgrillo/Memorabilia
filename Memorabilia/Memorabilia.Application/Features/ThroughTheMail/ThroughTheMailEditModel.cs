namespace Memorabilia.Application.Features.ThroughTheMail;

public class ThroughTheMailEditModel : EditModel
{
	public ThroughTheMailEditModel() { }

	public ThroughTheMailEditModel(Entity.ThroughTheMail throughTheMail)
	{
        if (throughTheMail.Address != null)
            Address = new(throughTheMail.Address);

		AddressId = throughTheMail.AddressId;
		Id = throughTheMail.Id;
        Notes = throughTheMail.Notes;
        Person = new PersonEditModel(new PersonModel(throughTheMail.Person));
		ReceivedDate = throughTheMail.ReceivedDate;
        SelfAddressedStampedEnvelopeTrackingNumber = throughTheMail.SelfAddressedStampedEnvelopeTrackingNumber;
		SentDate = throughTheMail.SentDate;
        ThroughTheMailFailureType = Constant.ThroughTheMailFailureType.Find(throughTheMail.ThroughTheMailFailureTypeId ?? 0);
        TrackingNumber = throughTheMail.TrackingNumber;
        UserId = throughTheMail.UserId;

		if (throughTheMail.Memorabilia.Count == 0)
			return;

		Memorabilia = throughTheMail.Memorabilia
								    .Select(memorabilia => new ThroughTheMailMemorabiliaEditModel(memorabilia, throughTheMail))
									.ToList();
	}

    public ThroughTheMailEditModel(ThroughTheMailModel model)
    {
        Address = new(model.Address);
        AddressId = model.Address?.Id;
        Id = model.Id;
        Notes = model.Notes;
        Person = new PersonEditModel(new PersonModel(model.Person));
        ReceivedDate = model.ReceivedDate;
        SelfAddressedStampedEnvelopeTrackingNumber = model.SelfAddressedStampedEnvelopeTrackingNumber;
        SentDate = model.SentDate;        
        ThroughTheMailFailureType = Constant.ThroughTheMailFailureType.Find(model.ThroughTheMailFailureTypeId ?? 0);
        TrackingNumber = model.TrackingNumber;
        UserId = model.UserId;

        if (model.Memorabilia.Length == 0)
            return;

        Memorabilia = model.Memorabilia
                           .Select(memorabilia => new ThroughTheMailMemorabiliaEditModel(memorabilia, model))
                           .ToList();
    }

    public AddressEditModel Address { get; set; }
        = new();

    public int? AddressId { get; set; }

	public List<ThroughTheMailMemorabiliaEditModel> Memorabilia { get; set; }
		= [];

    public string Notes { get; set; }

    public PersonEditModel Person { get; set; }
        = new();

    public DateTime? ReceivedDate { get; set; }

    public string SelfAddressedStampedEnvelopeTrackingNumber { get; set; }

    public DateTime? SentDate { get; set; }

    public Constant.ThroughTheMailFailureType ThroughTheMailFailureType { get; set; }

    public int? ThroughTheMailFailureTypeId 
        => ThroughTheMailFailureType?.Id;

    public string TrackingNumber { get; set; }

    public int UserId { get; set; }
}
