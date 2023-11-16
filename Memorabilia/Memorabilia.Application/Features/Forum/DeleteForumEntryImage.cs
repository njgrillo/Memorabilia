namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.EditForum)]
public record DeleteForumEntryImage(int ForumEntryImageId)
    : ICommand
{
    public class Handler(IForumEntryImageRepository forumEntryImageRepository) 
        : CommandHandler<DeleteForumEntryImage>
    {
        protected override async Task Handle(DeleteForumEntryImage command)
        {
            Entity.ForumEntryImage forumEntryImage
                = await forumEntryImageRepository.Get(command.ForumEntryImageId);

            await forumEntryImageRepository.Delete(forumEntryImage);
        }
    }
}
