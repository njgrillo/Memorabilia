namespace Memorabilia.Repository.Implementations;

public class SignatureReviewRepository
     : MemorabiliaRepository<SignatureReview>, ISignatureReviewRepository
{
    public SignatureReviewRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<PagedResult<SignatureReview>> GetAll(PageInfo pageInfo, int? userId = null)
    {
        var query =
            from signatureReview in Context.SignatureReview
            where userId == null || signatureReview.CreatedUserId == userId
            orderby signatureReview.CreatedDate descending
            select new SignatureReview(signatureReview);

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<SignatureReview> GetRandom()
    {
        int[] ids = Items.Select(signatureReview => signatureReview.Id)
                         .Distinct()
                         .ToArray();

        Random random = new();

        int index = random.Next(0, ids.Length - 1);

        return await Items.SingleAsync(signatureReview => signatureReview.Id == ids[index]);
    }
}
