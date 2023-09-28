namespace Memorabilia.Application.Features.SignatureIdentification;

public record GetSignatureIdentification(int SignatureIdentificationId)
    : IQuery<Entity.SignatureIdentification>
{
    public class Handler : QueryHandler<GetSignatureIdentification, Entity.SignatureIdentification>
    {
        private readonly ISignatureIdentificationRepository _signatureIdentificationRepository;

        public Handler(ISignatureIdentificationRepository signatureIdentificationRepository)
        {
            _signatureIdentificationRepository = signatureIdentificationRepository;
        }

        protected override async Task<Entity.SignatureIdentification> Handle(GetSignatureIdentification query)
            => await _signatureIdentificationRepository.Get(query.SignatureIdentificationId);
    }
}
