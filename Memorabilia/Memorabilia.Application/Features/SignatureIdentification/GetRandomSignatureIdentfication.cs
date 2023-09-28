namespace Memorabilia.Application.Features.SignatureIdentification;

public record GetRandomSignatureIdentfication
    : IQuery<Entity.SignatureIdentification>
{
    public class Handler : QueryHandler<GetRandomSignatureIdentfication, Entity.SignatureIdentification>
    {
        private readonly ISignatureIdentificationRepository _signatureIdentificationRepository;

        public Handler(ISignatureIdentificationRepository signatureIdentificationRepository)
        {
            _signatureIdentificationRepository = signatureIdentificationRepository;
        }

        protected override async Task<Entity.SignatureIdentification> Handle(GetRandomSignatureIdentfication query)
            => await _signatureIdentificationRepository.GetRandom();
    }
}
