namespace Memorabilia.Application.Features.SignatureReview;

public record GetSignatureReviews(PageInfo PageInfo)
    : IQuery<SignatureReviewsModel>
{
    public class Handler : QueryHandler<GetSignatureReviews, SignatureReviewsModel>
    {
        private readonly ISignatureReviewRepository _signatureReviewRepository;

        public Handler(ISignatureReviewRepository signatureReviewRepository)
        {
            _signatureReviewRepository = signatureReviewRepository;
        }

        protected override async Task<SignatureReviewsModel> Handle(GetSignatureReviews query)
        {
            PagedResult<Entity.SignatureReview> result
                = await _signatureReviewRepository.GetAll(query.PageInfo);

            return new SignatureReviewsModel(result.Data, result.PageInfo);
        }
    }
}
