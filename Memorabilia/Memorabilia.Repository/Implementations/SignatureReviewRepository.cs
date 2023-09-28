namespace Memorabilia.Repository.Implementations;

public class SignatureReviewRepository
     : MemorabiliaRepository<Entity.SignatureReview>, ISignatureReviewRepository
{
    public SignatureReviewRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<PagedResult<Entity.SignatureReview>> GetAll(PageInfo pageInfo)
    {
        var query =
            from signatureReview in Context.SignatureReview
            orderby signatureReview.CreatedDate descending
            select new Entity.SignatureReview(signatureReview);

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<Entity.SignatureReview> GetRandom()
    {
        int[] ids = Items.Select(signatureReview => signatureReview.Id)
                         .Distinct()
                         .ToArray();

        Random random = new();

        int index = random.Next(0, ids.Length - 1);

        return await Items.SingleAsync(signatureReview => signatureReview.Id == ids[index]);
    }
}
