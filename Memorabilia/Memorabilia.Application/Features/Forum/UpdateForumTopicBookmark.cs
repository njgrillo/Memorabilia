namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.Forum)]
public record UpdateForumTopicBookmark(int ForumTopicId, int UserId)
    : ICommand
{
    public class Handler : CommandHandler<UpdateForumTopicBookmark>
    {
        private readonly IForumTopicRepository _forumTopicRepository;

        public Handler(IForumTopicRepository forumTopicRepository)
        {
            _forumTopicRepository = forumTopicRepository;
        }

        protected override async Task Handle(UpdateForumTopicBookmark command)
        {
            Entity.ForumTopic forumTopic
                = await _forumTopicRepository.Get(command.ForumTopicId);

            forumTopic.SetBookmark(command.UserId);

            await _forumTopicRepository.Update(forumTopic);
        }
    }
}
