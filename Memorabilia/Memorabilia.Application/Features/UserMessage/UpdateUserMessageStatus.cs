namespace Memorabilia.Application.Features.UserMessage;

public record UpdateUserMessageStatus(int UserMessageId, int UserMessageStatusId)
    : ICommand
{
    public class Handler : CommandHandler<UpdateUserMessageStatus>
    {
        private readonly IUserMessageRepository _userMessageRepository;

        public Handler(IUserMessageRepository userMessageRepository)
        {
            _userMessageRepository = userMessageRepository;
        }

        protected override async Task Handle(UpdateUserMessageStatus command)
        {
            Entity.UserMessage userMessage
                = await _userMessageRepository.Get(command.UserMessageId);

            userMessage.SetStatus(command.UserMessageStatusId);

            await _userMessageRepository.Update(userMessage);
        }
    }
}
