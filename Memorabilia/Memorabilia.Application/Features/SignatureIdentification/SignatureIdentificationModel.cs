namespace Memorabilia.Application.Features.SignatureIdentification;

public class SignatureIdentificationModel
{
	private readonly Entity.SignatureIdentification _signatureIdentification;

	public SignatureIdentificationModel() { }

	public SignatureIdentificationModel(Entity.SignatureIdentification signatureIdentification)
	{
        _signatureIdentification = signatureIdentification;

		Images = _signatureIdentification.Images
										 .Select(image => new SignatureIdentificationImageModel(image))
										 .ToArray();

        People = _signatureIdentification.People
                                         .Select(person => new SignatureIdentificationPersonModel(person))
                                         .ToArray();
    }

	public PersonModel ConsensusPerson
		=> People.Any()
			? People.FirstOrDefault(person => person.PersonId == ConsensusPersonId)?.Person ?? null
			: null;

	public int ConsensusPersonId
        => People.Any()
			? People.GroupBy(x => x.Person.Id)
				    .OrderByDescending(x => x.Count())
					.First()
					.Key
			: 0;

    public DateTime CreatedDate
		=> _signatureIdentification.CreatedDate;

	public UserModel CreatedUser
		=> new(_signatureIdentification.CreatedUser);

	public bool DisplayDetails { get; set; }

    public int Id
		=> _signatureIdentification.Id;

	public SignatureIdentificationImageModel[] Images { get; set; }
		= Array.Empty<SignatureIdentificationImageModel>();

    public string Note
		=> _signatureIdentification.Note;

	public SignatureIdentificationPersonModel[] People { get; set; }
		= Array.Empty<SignatureIdentificationPersonModel>();

    public string ToggleIcon { get; set; }
        = MudBlazor.Icons.Material.Filled.ExpandMore;
}
