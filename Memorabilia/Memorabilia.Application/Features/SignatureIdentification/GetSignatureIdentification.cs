namespace Memorabilia.Application.Features.SignatureIdentification;

public record GetSignatureIdentification(int SignatureIdentificationId)
    : IQuery<Entity.SignatureIdentification>
{
    public class Handler(ISignatureIdentificationRepository signatureIdentificationRepository) 
        : QueryHandler<GetSignatureIdentification, Entity.SignatureIdentification>
    {
        protected override async Task<Entity.SignatureIdentification> Handle(GetSignatureIdentification query)
            => await signatureIdentificationRepository.Get(query.SignatureIdentificationId);
    }
}
