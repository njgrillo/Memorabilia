namespace Memorabilia.Application.Features.SignatureReview;

public record GetRandomSignatureReview()
    : IQuery<Entity.SignatureReview>
{
    public class Handler(ISignatureReviewRepository signatureReviewRepository) 
        : QueryHandler<GetRandomSignatureReview, Entity.SignatureReview>
    {
        protected override async Task<Entity.SignatureReview> Handle(GetRandomSignatureReview query)
            => await signatureReviewRepository.GetRandom();
    }
}
