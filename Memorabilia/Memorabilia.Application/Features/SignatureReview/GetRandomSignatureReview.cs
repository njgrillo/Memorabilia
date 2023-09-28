namespace Memorabilia.Application.Features.SignatureReview;

public record GetRandomSignatureReview()
    : IQuery<Entity.SignatureReview>
{
    public class Handler : QueryHandler<GetRandomSignatureReview, Entity.SignatureReview>
    {
        private readonly ISignatureReviewRepository _signatureReviewRepository;

        public Handler(ISignatureReviewRepository signatureReviewRepository)
        {
            _signatureReviewRepository = signatureReviewRepository;
        }

        protected override async Task<Entity.SignatureReview> Handle(GetRandomSignatureReview query)
            => await _signatureReviewRepository.GetRandom();
    }
}
