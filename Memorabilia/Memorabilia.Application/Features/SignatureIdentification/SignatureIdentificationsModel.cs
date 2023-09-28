namespace Memorabilia.Application.Features.SignatureIdentification;

public class SignatureIdentificationsModel : Model
{
    public SignatureIdentificationsModel() { }

    public SignatureIdentificationsModel(Entity.SignatureIdentification[] signatureIdentifications)
    {
        SignatureIdentifications 
            = signatureIdentifications.Select(signatureIdentification => new SignatureIdentificationModel(signatureIdentification))
                                      .ToList();
    }

    public SignatureIdentificationsModel(Entity.SignatureIdentification[] signatureIdentifications, 
                                         PageInfoResult pageInfo)
    {
        SignatureIdentifications 
            = signatureIdentifications.Select(signatureIdentification => new SignatureIdentificationModel(signatureIdentification))
                                      .ToList();

        PageInfo = pageInfo;
    }

    public List<SignatureIdentificationModel> SignatureIdentifications { get; set; }
        = new();
}
