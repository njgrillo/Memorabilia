namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.EditForum)]
public record SaveForumEntry(int ForumEntryId, string Message)
    : ICommand
{
    public class Handler : CommandHandler<SaveForumEntry>
    {
        private readonly IForumEntryRepository _forumEntryRepository;

        public Handler(IForumEntryRepository forumEntryRepository)
        {
            _forumEntryRepository = forumEntryRepository;
        }

        protected override async Task Handle(SaveForumEntry command)
        {
            Entity.ForumEntry forumEntry
                = await _forumEntryRepository.Get(command.ForumEntryId);  

            forumEntry.Set(DateTime.UtcNow, command.Message);

            await _forumEntryRepository.Update(forumEntry);
        }
    }
}
