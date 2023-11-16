namespace Memorabilia.Application.Features.SignatureReview;

public record GetSignatureReview(int SignatureReviewId)
    : IQuery<Entity.SignatureReview>
{
    public class Handler(ISignatureReviewRepository signatureReviewRepository) 
        : QueryHandler<GetSignatureReview, Entity.SignatureReview>
    {
        protected override async Task<Entity.SignatureReview> Handle(GetSignatureReview query)
            => await signatureReviewRepository.Get(query.SignatureReviewId);
    }
}
