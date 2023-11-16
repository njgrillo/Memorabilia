namespace Memorabilia.Application.Features.SignatureIdentification;

public record GetSignatureIdentifications(PageInfo PageInfo, bool? FilterByUser = null)
    : IQuery<SignatureIdentificationsModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         ISignatureIdentificationRepository signatureIdentificationRepository) 
        : QueryHandler<GetSignatureIdentifications, SignatureIdentificationsModel>
    {
        protected override async Task<SignatureIdentificationsModel> Handle(GetSignatureIdentifications query)
        {
            PagedResult<Entity.SignatureIdentification> result
                = (query.FilterByUser ?? false) 
                    ? await signatureIdentificationRepository.GetAll(query.PageInfo, applicationStateService.CurrentUser.Id)
                    : await signatureIdentificationRepository.GetAll(query.PageInfo);

            return new SignatureIdentificationsModel(result.Data, result.PageInfo);
        }
    }
}
