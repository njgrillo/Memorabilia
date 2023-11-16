namespace Memorabilia.Application.Features.UserMessage;

public record GetUserMessageReply(int UserMessageReplyId)
    : IQuery<Entity.UserMessageReply>
{
    public class Handler(IUserMessageReplyRepository userMessageReplyRepository) 
        : QueryHandler<GetUserMessageReply, Entity.UserMessageReply>
    {
        protected override async Task<Entity.UserMessageReply> Handle(GetUserMessageReply query)
            => await userMessageReplyRepository.Get(query.UserMessageReplyId);
    }
}
