namespace Memorabilia.Repository.Implementations;

public class UserPaymentOptionRepository
    : DomainRepository<UserPaymentOption>, IUserPaymentOptionRepository
{
    public UserPaymentOptionRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }
}
