namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.EditForum)]
public record SaveForumEntry(int ForumEntryId, string Message)
    : ICommand
{
    public class Handler(IForumEntryRepository forumEntryRepository) 
        : CommandHandler<SaveForumEntry>
    {
        protected override async Task Handle(SaveForumEntry command)
        {
            Entity.ForumEntry forumEntry
                = await forumEntryRepository.Get(command.ForumEntryId);  

            forumEntry.Set(DateTime.UtcNow, command.Message);

            await forumEntryRepository.Update(forumEntry);
        }
    }
}
