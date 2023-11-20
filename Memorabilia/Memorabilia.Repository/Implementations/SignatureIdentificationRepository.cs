namespace Memorabilia.Repository.Implementations;

public class SignatureIdentificationRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<SignatureIdentification>(context, memoryCache), ISignatureIdentificationRepository
{
    public async Task<PagedResult<SignatureIdentification>> GetAll(PageInfo pageInfo,
                                                                   int userId,
                                                                   bool excludeLoggedInUser)
    {
        var query =
            from signatureIdentification in Context.SignatureIdentification
            where (excludeLoggedInUser == true && signatureIdentification.CreatedUserId != userId)
               || (excludeLoggedInUser == false && signatureIdentification.CreatedUserId == userId)
            orderby signatureIdentification.CreatedDate descending
            select new SignatureIdentification(signatureIdentification);

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<SignatureIdentification> GetRandom()
    {
        int[] ids = Items.Select(signatureIdentification => signatureIdentification.Id)
                         .Distinct()
                         .ToArray();

        Random random = new();

        int index = random.Next(0, ids.Length - 1);

        return await Items.SingleAsync(signatureIdentification => signatureIdentification.Id == ids[index]);
    }
}
