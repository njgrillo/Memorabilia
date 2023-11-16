namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.EditForum)]
public record UpdateForumEntryRank(int ForumEntryId, int UserId, bool IncreaseRank)
    : ICommand
{
    public class Handler(IForumEntryRepository forumEntryRepository) 
        : CommandHandler<UpdateForumEntryRank>
    {
        protected override async Task Handle(UpdateForumEntryRank command)
        {
            Entity.ForumEntry forumEntry
                = await forumEntryRepository.Get(command.ForumEntryId);

            if (command.IncreaseRank)
                forumEntry.IncreaseRank(command.UserId);
            else
                forumEntry.DecreaseRank(command.UserId);

            await forumEntryRepository.Update(forumEntry);
        }
    }
}
