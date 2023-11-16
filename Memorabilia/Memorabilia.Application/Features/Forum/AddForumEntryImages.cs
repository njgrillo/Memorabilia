namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.EditForum)]
public record AddForumEntryImages(int ForumEntryId,
                                  ForumEntryImageEditModel[] ForumEntryImages)
    : ICommand
{
    public class Handler(IForumEntryRepository forumEntryRepository) 
        : CommandHandler<AddForumEntryImages>
    {
        protected override async Task Handle(AddForumEntryImages command)
        {
            Entity.ForumEntry forumEntry
                = await forumEntryRepository.Get(command.ForumEntryId);

            foreach (ForumEntryImageEditModel image in command.ForumEntryImages.Where(forumEntryImage => !forumEntryImage.IsDeleted)) 
            {
                forumEntry.AddImage(image.ImageFileName);
            }

            await forumEntryRepository.Update(forumEntry);
        }
    }
}
