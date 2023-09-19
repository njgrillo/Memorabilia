namespace Memorabilia.Repository.Implementations;

public class ForumTopicRepository
    : DomainRepository<Entity.ForumTopic>, IForumTopicRepository
{
    public ForumTopicRepository(DomainContext context, IMemoryCache memoryCache)
        : base(context, memoryCache) { }

    public async Task<PagedResult<Entity.ForumTopic>> GetAll(PageInfo pageInfo, int forumCategoryId, int? sportId)
    {
        var query =
            from forumTopic in Context.ForumTopic
            where forumTopic.ForumCategoryId == forumCategoryId
               && (sportId == null || forumTopic.SportId == sportId.Value)
            orderby forumTopic.CreatedDate descending
            select forumTopic;

        return await query.ToPagedResult(pageInfo);
    }

    public async Task<Entity.ForumTopic[]> GetAllBookmarked(int userId)
    {
        var query =
            from forumTopic in Context.ForumTopic
            join forumTopicUserBookmark in Context.ForumTopicUserBookmark on forumTopic.Id equals forumTopicUserBookmark.ForumTopicId 
            where forumTopicUserBookmark.UserId == userId
            orderby forumTopic.CreatedDate descending
            select forumTopic;

        return await query.ToArrayAsync();
    }

    public async Task<Entity.ForumTopic[]> GetAllTrending()
    {
        DateTime previousUtcDate = DateTime.UtcNow.AddDays(-1);

        int[] topRankedForumTopicIds 
            = await Items.SelectMany(item => item.Entries)
                         .Where(item => item.CreatedDate > previousUtcDate || item.ModifiedDate > previousUtcDate)
                         .OrderByDescending(entry => entry.Rank)                          
                         .Select(item => item.ForumTopicId)
                         .Distinct()
                         .Take(3)   
                         .ToArrayAsync();

        int[] popularForumTopicIds
            = await Items.Where(item => item.Entries.Max(entry => entry.CreatedDate) > previousUtcDate || item.Entries.Max(entry => entry.ModifiedDate) > previousUtcDate)
                         .OrderByDescending(item => item.Entries.Count())
                         .Select(item => item.Id)
                         .Distinct()
                         .Take(3)
                         .ToArrayAsync();

        int[] forumTopicIds 
            = topRankedForumTopicIds.Union(popularForumTopicIds)
                                    .Distinct()
                                    .Take(6)
                                    .ToArray();


        return await Items.Where(item => forumTopicIds.Contains(item.Id))
                          .ToArrayAsync();
    }

    public async Task<PagedResult<Entity.ForumTopic>> Search(PageInfo pageInfo, string searchText)
    {
        var query =
            from forumTopic in Context.ForumTopic
            join forumCategory in Context.ForumCategory on forumTopic.ForumCategoryId equals forumCategory.Id
            join forumEntry in Context.ForumEntry on forumTopic.Id equals forumEntry.ForumTopicId     
            join user in Context.User on forumTopic.CreatedByUserId equals user.Id
            where forumCategory.Name.Contains(searchText)
               || (forumTopic.SportId == null || forumTopic.Sport.Name.Contains(searchText))
               || forumTopic.Subject.Contains(searchText)
               || forumEntry.Message.Contains(searchText)
            orderby forumTopic.CreatedDate descending
            group new { }
            by new
            {
                forumTopic.Id,
                forumTopic.ForumCategoryId,
                forumTopic.Subject,
                forumTopic.SportId,
                forumTopic.CreatedDate,
                forumTopic.CreatedByUserId,
                forumTopic.ModifiedDate,
                user.Username
            } into groupedList
            select new Entity.ForumTopic
            (
                groupedList.Key.CreatedDate,
                groupedList.Key.CreatedByUserId,
                groupedList.Key.ForumCategoryId,
                groupedList.Key.Id,
                groupedList.Key.ModifiedDate,
                groupedList.Key.SportId,
                groupedList.Key.Subject,
                groupedList.Key.Username
            );

        return await query.ToPagedResult(pageInfo);
    }
}
