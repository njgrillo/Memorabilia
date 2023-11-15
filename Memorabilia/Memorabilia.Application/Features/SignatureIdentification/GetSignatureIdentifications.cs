namespace Memorabilia.Application.Features.SignatureIdentification;

public record GetSignatureIdentifications(PageInfo PageInfo, bool? FilterByUser = null)
    : IQuery<SignatureIdentificationsModel>
{
    public class Handler : QueryHandler<GetSignatureIdentifications, SignatureIdentificationsModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly ISignatureIdentificationRepository _signatureIdentificationRepository;

        public Handler(IApplicationStateService applicationStateService,
                       ISignatureIdentificationRepository signatureIdentificationRepository)
        {
            _applicationStateService = applicationStateService;
            _signatureIdentificationRepository = signatureIdentificationRepository;
        }

        protected override async Task<SignatureIdentificationsModel> Handle(GetSignatureIdentifications query)
        {
            PagedResult<Entity.SignatureIdentification> result
                = (query.FilterByUser ?? false) 
                    ? await _signatureIdentificationRepository.GetAll(query.PageInfo, _applicationStateService.CurrentUser.Id)
                    : await _signatureIdentificationRepository.GetAll(query.PageInfo);

            return new SignatureIdentificationsModel(result.Data, result.PageInfo);
        }
    }
}
