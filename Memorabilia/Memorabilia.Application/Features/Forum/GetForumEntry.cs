namespace Memorabilia.Application.Features.Forum;

public record GetForumEntry(int ForumEntryId)
    : IQuery<Entity.ForumEntry>
{
    public class Handler(IForumEntryRepository forumEntryRepository) 
        : QueryHandler<GetForumEntry, Entity.ForumEntry>
    {
        protected override async Task<Entity.ForumEntry> Handle(GetForumEntry query)
            => await forumEntryRepository.Get(query.ForumEntryId);
    }
}
