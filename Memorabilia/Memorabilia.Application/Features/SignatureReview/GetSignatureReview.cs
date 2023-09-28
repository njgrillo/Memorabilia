namespace Memorabilia.Application.Features.SignatureReview;

public record GetSignatureReview(int SignatureReviewId)
    : IQuery<Entity.SignatureReview>
{
    public class Handler : QueryHandler<GetSignatureReview, Entity.SignatureReview>
    {
        private readonly ISignatureReviewRepository _signatureReviewRepository;

        public Handler(ISignatureReviewRepository signatureReviewRepository)
        {
            _signatureReviewRepository = signatureReviewRepository;
        }

        protected override async Task<Entity.SignatureReview> Handle(GetSignatureReview query)
            => await _signatureReviewRepository.Get(query.SignatureReviewId);
    }
}
