namespace Memorabilia.Application.Features.PrivateSigning;

public class PrivateSigningPersonEditModel : EditModel
{
	public PrivateSigningPersonEditModel() { }

	public PrivateSigningPersonEditModel(Entity.PrivateSigningPerson privateSigningPerson)
	{
		AllowInscriptions = privateSigningPerson.AllowInscriptions;
		Id = privateSigningPerson.Id;
		InscriptionCost = privateSigningPerson.InscriptionCost;
		Note = privateSigningPerson.Note;
		Person = new PersonModel(privateSigningPerson.Person);
		PersonId = privateSigningPerson.PersonId;
		PrivateSigningId = privateSigningPerson.PrivateSigningId;
		PromoterImageFileName = privateSigningPerson.PromoterImageFileName;
		SigningDate = privateSigningPerson.SigningDate?.ToDateTime(TimeOnly.MinValue); 
		SpotsAvailable = privateSigningPerson.SpotsAvailable;
		SpotsConfirmed = privateSigningPerson.SpotsConfirmed;
		SpotsReserved = privateSigningPerson.SpotsReserved;
		StatusId = privateSigningPerson.StatusId;

        ExcludedItems = privateSigningPerson.ExcludedItems
											.Select(item => new PrivateSigningPersonExcludeItemTypeEditModel(item))
											.ToList();

        Pricing = privateSigningPerson.Pricing
                                      .Select(pricing => new PrivateSigningPersonDetailEditModel(pricing))
                                      .ToList();
    }

	public bool AllowInscriptions { get; set; }

	public List<PrivateSigningPersonExcludeItemTypeEditModel> ExcludedItems { get; set; }
		= [];

	public decimal? InscriptionCost { get; set; }

	public string Note { get; set; }

	public PersonModel Person { get; set; }
		= new();

    public int PersonId { get; set; }

	public List<PrivateSigningPersonDetailEditModel> Pricing { get; set; }
		= [];

    public int PrivateSigningId { get; set; }

	public string PromoterImageFileName { get; set; }

	public DateTime? SigningDate { get; set; }

	public int? SpotsAvailable { get; set; }

	public int? SpotsConfirmed { get; set; }

	public int? SpotsReserved { get; set; }

	public int StatusId { get; set; }
		= Constant.PrivateSigningStatus.Pending.Id;

    public string StatusName 
        => Constant.PrivateSigningStatus.Find(StatusId)?.Name;
}
