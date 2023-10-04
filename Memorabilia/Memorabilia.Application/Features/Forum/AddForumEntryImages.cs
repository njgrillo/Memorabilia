namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.EditForum)]
public record AddForumEntryImages(int ForumEntryId,
                                  ForumEntryImageEditModel[] ForumEntryImages)
    : ICommand
{
    public class Handler : CommandHandler<AddForumEntryImages>
    {
        private readonly IForumEntryRepository _forumEntryRepository;

        public Handler(IForumEntryRepository forumEntryRepository)
        {
            _forumEntryRepository = forumEntryRepository;
        }

        protected override async Task Handle(AddForumEntryImages command)
        {
            Entity.ForumEntry forumEntry
                = await _forumEntryRepository.Get(command.ForumEntryId);

            foreach (ForumEntryImageEditModel image in command.ForumEntryImages.Where(forumEntryImage => !forumEntryImage.IsDeleted)) 
            {
                forumEntry.AddImage(image.Image);
            }

            await _forumEntryRepository.Update(forumEntry);
        }
    }
}
