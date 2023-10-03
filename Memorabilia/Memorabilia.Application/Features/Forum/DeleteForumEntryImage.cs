namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.Forum)]
public record DeleteForumEntryImage(int ForumEntryImageId)
    : ICommand
{
    public class Handler : CommandHandler<DeleteForumEntryImage>
    {
        private readonly IForumEntryImageRepository _forumEntryImageRepository;

        public Handler(IForumEntryImageRepository forumEntryImageRepository)
        {
            _forumEntryImageRepository = forumEntryImageRepository;
        }

        protected override async Task Handle(DeleteForumEntryImage command)
        {
            Entity.ForumEntryImage forumEntryImage
                = await _forumEntryImageRepository.Get(command.ForumEntryImageId);

            await _forumEntryImageRepository.Delete(forumEntryImage);
        }
    }
}
