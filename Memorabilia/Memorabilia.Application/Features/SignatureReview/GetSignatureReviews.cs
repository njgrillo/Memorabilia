namespace Memorabilia.Application.Features.SignatureReview;

public record GetSignatureReviews(PageInfo PageInfo, bool? FilterByUser = null)
    : IQuery<SignatureReviewsModel>
{
    public class Handler : QueryHandler<GetSignatureReviews, SignatureReviewsModel>
    {
        private readonly IApplicationStateService _applicationStateService;
        private readonly ISignatureReviewRepository _signatureReviewRepository;

        public Handler(IApplicationStateService applicationStateService, 
                       ISignatureReviewRepository signatureReviewRepository)
        {
            _applicationStateService = applicationStateService;
            _signatureReviewRepository = signatureReviewRepository;
        }

        protected override async Task<SignatureReviewsModel> Handle(GetSignatureReviews query)
        {
            PagedResult<Entity.SignatureReview> result
                = (query.FilterByUser ?? false)
                    ? await _signatureReviewRepository.GetAll(query.PageInfo, _applicationStateService.CurrentUser.Id)
                    : await _signatureReviewRepository.GetAll(query.PageInfo);

            return new SignatureReviewsModel(result.Data, result.PageInfo);
        }
    }
}
