namespace Memorabilia.Application.Features.Forum;

public record GetForumTopic(int ForumTopicId)
    : IQuery<Entity.ForumTopic>
{
    public class Handler(IForumTopicRepository forumTopicRepository) 
        : QueryHandler<GetForumTopic, Entity.ForumTopic>
    {
        protected override async Task<Entity.ForumTopic> Handle(GetForumTopic query)
            => await forumTopicRepository.Get(query.ForumTopicId);
    }
}
