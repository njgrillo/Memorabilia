﻿namespace Memorabilia.Repository.Implementations;

public class UserSocialMediaRepository
    : DomainRepository<Entity.UserSocialMedia>, IUserSocialMediaRepository
{
    public UserSocialMediaRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }
}
