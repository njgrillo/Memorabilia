namespace Memorabilia.Application.Features.Forum;

[AuthorizeByPermission(Enum.Permission.EditForumBookmark)]
public record GetBookmarkedForumTopics(int UserId)
     : IQuery<Entity.ForumTopic[]>
{
    public class Handler(IForumTopicRepository forumTopicRepository) 
        : QueryHandler<GetBookmarkedForumTopics, Entity.ForumTopic[]>
    {
        protected override async Task<Entity.ForumTopic[]> Handle(GetBookmarkedForumTopics query)
            => await forumTopicRepository.GetAllBookmarked(query.UserId);
    }
}
