namespace Memorabilia.Application.Features.UserMessage;

public record GetUserMessage(int UserMessageId)
    : IQuery<Entity.UserMessage>
{
    public class Handler(IUserMessageRepository userMessageRepository) 
        : QueryHandler<GetUserMessage, Entity.UserMessage>
    {
        protected override async Task<Entity.UserMessage> Handle(GetUserMessage query)
            => await userMessageRepository.Get(query.UserMessageId);
    }
}
