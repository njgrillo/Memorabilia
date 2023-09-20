namespace Memorabilia.Application.Features.Forum;

public record GetForumEntry(int ForumEntryId)
    : IQuery<Entity.ForumEntry>
{
    public class Handler : QueryHandler<GetForumEntry, Entity.ForumEntry>
    {
        private readonly IForumEntryRepository _forumEntryRepository;

        public Handler(IForumEntryRepository forumEntryRepository)
        {
            _forumEntryRepository = forumEntryRepository;
        }

        protected override async Task<Entity.ForumEntry> Handle(GetForumEntry query)
            => await _forumEntryRepository.Get(query.ForumEntryId);
    }
}
