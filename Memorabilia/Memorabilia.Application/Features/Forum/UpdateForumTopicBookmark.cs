namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.EditForumBookmark)]
public record UpdateForumTopicBookmark(int ForumTopicId, int UserId)
    : ICommand
{
    public class Handler(IForumTopicRepository forumTopicRepository) 
        : CommandHandler<UpdateForumTopicBookmark>
    {
        protected override async Task Handle(UpdateForumTopicBookmark command)
        {
            Entity.ForumTopic forumTopic
                = await forumTopicRepository.Get(command.ForumTopicId);

            forumTopic.SetBookmark(command.UserId);

            await forumTopicRepository.Update(forumTopic);
        }
    }
}
