namespace Memorabilia.Application.Features.SignatureReview;

public record GetSignatureReviews(PageInfo PageInfo, 
                                  bool ExcludeLoggedInUser)
    : IQuery<SignatureReviewsModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         ISignatureReviewRepository signatureReviewRepository) 
        : QueryHandler<GetSignatureReviews, SignatureReviewsModel>
    {
        protected override async Task<SignatureReviewsModel> Handle(GetSignatureReviews query)
        {
            PagedResult<Entity.SignatureReview> result
                = await signatureReviewRepository.GetAll(query.PageInfo,
                                                         applicationStateService.CurrentUser.Id,
                                                         query.ExcludeLoggedInUser);

            return new SignatureReviewsModel(result.Data, result.PageInfo);
        }
    }
}
