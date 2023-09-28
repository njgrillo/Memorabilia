namespace Memorabilia.Application.Features.SignatureIdentification;

public class SignatureIdentificationImageEditModel : EditModel
{
	public SignatureIdentificationImageEditModel() { }

	public SignatureIdentificationImageEditModel(string fileName)
	{
		FileName = fileName;
	}

	public SignatureIdentificationImageEditModel(Entity.SignatureIdentificationImage signatureIdentificationImage)
	{
		FileName = signatureIdentificationImage.FileName;
		Id = signatureIdentificationImage.Id;
		SignatureIdentificationId = signatureIdentificationImage.SignatureIdentificationId;
	}

	public string FileName { get; set; }

	public int SignatureIdentificationId { get; set; }
}
