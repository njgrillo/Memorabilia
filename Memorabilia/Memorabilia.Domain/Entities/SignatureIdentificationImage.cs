namespace Memorabilia.Domain.Entities;

public class SignatureIdentificationImage : DomainIdEntity
{
    public SignatureIdentificationImage() { }

    public SignatureIdentificationImage(string fileName,
                                        int signatureIdentificationId)
    {
        FileName = fileName;
        SignatureIdentificationId = signatureIdentificationId;
    }

    public string FileName { get; private set; }

    public virtual SignatureIdentification SignatureIdentification { get; private set; }

    public int SignatureIdentificationId { get; private set; }    
}
