namespace Memorabilia.Repository.Implementations;

public class UserSocialMediaRepository(DomainContext context, IMemoryCache memoryCache)
    : DomainRepository<UserSocialMedia>(context, memoryCache), IUserSocialMediaRepository
{
}
