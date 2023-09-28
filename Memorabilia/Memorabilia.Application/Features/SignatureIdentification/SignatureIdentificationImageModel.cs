namespace Memorabilia.Application.Features.SignatureIdentification;

public class SignatureIdentificationImageModel
{
    private readonly Entity.SignatureIdentificationImage _signatureIdentificationImage;

    public SignatureIdentificationImageModel() { }

    public SignatureIdentificationImageModel(Entity.SignatureIdentificationImage signatureIdentificationImage)
    {
        _signatureIdentificationImage = signatureIdentificationImage;
    }

    public string FileName
        => _signatureIdentificationImage.FileName;

    public int Id
        => _signatureIdentificationImage.Id;

    public int SignatureIdentificationId
        => _signatureIdentificationImage.SignatureIdentificationId;

    public int UserId
        => _signatureIdentificationImage.SignatureIdentification.CreatedUserId;
}
