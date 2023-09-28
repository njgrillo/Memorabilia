namespace Memorabilia.Application.Features.SignatureIdentification;

public record GetSignatureIdentifications(PageInfo PageInfo)
    : IQuery<SignatureIdentificationsModel>
{
    public class Handler : QueryHandler<GetSignatureIdentifications, SignatureIdentificationsModel>
    {
        private readonly ISignatureIdentificationRepository _signatureIdentificationRepository;

        public Handler(ISignatureIdentificationRepository signatureIdentificationRepository)
        {
            _signatureIdentificationRepository = signatureIdentificationRepository;
        }

        protected override async Task<SignatureIdentificationsModel> Handle(GetSignatureIdentifications query)
        {
            PagedResult<Entity.SignatureIdentification> result
                = await _signatureIdentificationRepository.GetAll(query.PageInfo);

            return new SignatureIdentificationsModel(result.Data, result.PageInfo);
        }
    }
}
