namespace Memorabilia.Application.Features.SignatureIdentification;

public record GetRandomSignatureIdentfication
    : IQuery<Entity.SignatureIdentification>
{
    public class Handler(ISignatureIdentificationRepository signatureIdentificationRepository) 
        : QueryHandler<GetRandomSignatureIdentfication, Entity.SignatureIdentification>
    {
        protected override async Task<Entity.SignatureIdentification> Handle(GetRandomSignatureIdentfication query)
            => await signatureIdentificationRepository.GetRandom();
    }
}
