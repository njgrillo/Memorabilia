namespace Memorabilia.Application.Features.SignatureIdentification;

public record GetSignatureIdentifications(PageInfo PageInfo, 
                                          bool ExcludeLoggedInUser)
    : IQuery<SignatureIdentificationsModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         ISignatureIdentificationRepository signatureIdentificationRepository) 
        : QueryHandler<GetSignatureIdentifications, SignatureIdentificationsModel>
    {
        protected override async Task<SignatureIdentificationsModel> Handle(GetSignatureIdentifications query)
        {
            PagedResult<Entity.SignatureIdentification> result
                = await signatureIdentificationRepository.GetAll(query.PageInfo, 
                                                                 applicationStateService.CurrentUser.Id, 
                                                                 query.ExcludeLoggedInUser);

            return new SignatureIdentificationsModel(result.Data, result.PageInfo);
        }
    }
}
