namespace Memorabilia.Repository.Implementations;

public class UserPaymentOptionRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<UserPaymentOption>(context, memoryCache), IUserPaymentOptionRepository
{
}
