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
		PersonId = privateSigningPerson.PersonId;
		PrivateSigningId = privateSigningPerson.PrivateSigningId;
	}

	public bool AllowInscriptions { get; set; }

	public decimal? InscriptionCost { get; set; }

	public string Note { get; set; }

	public int PersonId { get; set; }

	public int PrivateSigningId { get; set; }
}
