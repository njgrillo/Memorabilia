﻿namespace Memorabilia.Repository.Implementations;

public class UserRepository 
    : DomainRepository<Entity.User>, IUserRepository
{
    public UserRepository(DomainContext context, IMemoryCache memoryCache) 
        : base(context, memoryCache) { }

    private IQueryable<Entity.User> User 
        => Items.Include(user => user.BookmarkedForumTopics)
                .Include(user => user.DashboardItems)
                .Include(user => user.UserSettings);

    public override async Task<Entity.User> Get(int id)
        => await User.SingleOrDefaultAsync(user => user.Id == id);

    public async Task<Entity.User> Get(string emailAddress)
        => await User.SingleOrDefaultAsync(user => user.EmailAddress == emailAddress);

    public async Task<Entity.User> GetByGoogleEmailAddress(string emailAddress)
        => await User.SingleOrDefaultAsync(user => user.UserSettings != null 
                                                && user.UserSettings.GoogleEmailAddress == emailAddress);

    public async Task<Entity.User> GetByMicrosoftEmailAddress(string emailAddress)
        => await User.SingleOrDefaultAsync(user => user.UserSettings != null
                                                && user.UserSettings.MicrosoftEmailAddress == emailAddress);

    public async Task<Entity.User> GetByUsername(string username)
        => await User.SingleOrDefaultAsync(user => user.Username == username);

    public async Task<Entity.User> GetByXHandle(string handle)
        => await User.SingleOrDefaultAsync(user => user.UserSettings != null
                                                && user.UserSettings.XHandle == handle);
}
