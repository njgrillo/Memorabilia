namespace Memorabilia.Application.Features.UserMessage;

public record GetUserMessage(int UserMessageId)
    : IQuery<Entity.UserMessage>
{
    public class Handler : QueryHandler<GetUserMessage, Entity.UserMessage>
    {
        private readonly IUserMessageRepository _userMessageRepository;

        public Handler(IUserMessageRepository userMessageRepository)
        {
            _userMessageRepository = userMessageRepository;
        }

        protected override async Task<Entity.UserMessage> Handle(GetUserMessage query)
            => await _userMessageRepository.Get(query.UserMessageId);
    }
}
