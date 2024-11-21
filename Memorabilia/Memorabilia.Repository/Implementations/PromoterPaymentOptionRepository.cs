namespace Memorabilia.Repository.Implementations;

public class PromoterPaymentOptionRepository(MemorabiliaContext context, IMemoryCache memoryCache)
    : MemorabiliaRepository<PromoterPaymentOption>(context, memoryCache), IPromoterPaymentOptionRepository
{
    public async Task<PromoterPaymentOption[]> GetAll(int userId)
        => await Items.Where(option => option.UserId == userId)
                      .ToArrayAsync();
}
