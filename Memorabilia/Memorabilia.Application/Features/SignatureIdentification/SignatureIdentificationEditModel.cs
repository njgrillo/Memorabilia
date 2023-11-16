namespace Memorabilia.Application.Features.SignatureIdentification;

public class SignatureIdentificationEditModel : EditModel
{
	public SignatureIdentificationEditModel() { }

	public SignatureIdentificationEditModel(Entity.SignatureIdentification signatureIdentification)
	{
		CreatedDate = signatureIdentification.CreatedDate;
		CreatedUserId= signatureIdentification.CreatedUserId;
		Id = signatureIdentification.Id;
		Note = signatureIdentification.Note;

		Images = signatureIdentification.Images
										.Select(image => new SignatureIdentificationImageEditModel(image))
										.ToList();

        People = signatureIdentification.People
                                        .Select(person => new SignatureIdentificationPersonEditModel(person))
                                        .ToList();
    }

    public DateTime CreatedDate { get; set; }

    public int CreatedUserId { get; set; }

	public List<SignatureIdentificationImageEditModel> Images { get; set; }
		= [];

    public string Note { get; set; }

    public List<SignatureIdentificationPersonEditModel> People { get; set; }
        = [];
}
