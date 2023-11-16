using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Application.Features.SignatureReview;

public record GetSignatureReviews(PageInfo PageInfo, bool? FilterByUser = null)
    : IQuery<SignatureReviewsModel>
{
    public class Handler(IApplicationStateService applicationStateService,
                         ISignatureReviewRepository signatureReviewRepository) 
        : QueryHandler<GetSignatureReviews, SignatureReviewsModel>
    {
        protected override async Task<SignatureReviewsModel> Handle(GetSignatureReviews query)
        {
            PagedResult<Entity.SignatureReview> result
                = (query.FilterByUser ?? false)
                    ? await signatureReviewRepository.GetAll(query.PageInfo, applicationStateService.CurrentUser.Id)
                    : await signatureReviewRepository.GetAll(query.PageInfo);

            return new SignatureReviewsModel(result.Data, result.PageInfo);
        }
    }
}
