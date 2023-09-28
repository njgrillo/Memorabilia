namespace Memorabilia.Repository.Implementations;

public class SignatureIdentificationRepository
     : MemorabiliaRepository<Entity.SignatureIdentification>, ISignatureIdentificationRepository
{
    public SignatureIdentificationRepository(MemorabiliaContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<PagedResult<Entity.SignatureIdentification>> GetAll(PageInfo pageInfo)
    {
        var query =
            from signatureIdentification in Context.SignatureIdentification
            orderby signatureIdentification.CreatedDate descending
            select new Entity.SignatureIdentification(signatureIdentification);

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<Entity.SignatureIdentification> GetRandom()
    {
        int[] ids = Items.Select(signatureIdentification => signatureIdentification.Id)
                         .Distinct()
                         .ToArray();

        Random random = new();

        int index = random.Next(0, ids.Length - 1);

        return await Items.SingleAsync(signatureIdentification => signatureIdentification.Id == ids[index]);
    }
}
