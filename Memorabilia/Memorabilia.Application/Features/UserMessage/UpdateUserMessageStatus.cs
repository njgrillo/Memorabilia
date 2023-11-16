namespace Memorabilia.Application.Features.UserMessage;

public record UpdateUserMessageStatus(int UserMessageId, int UserMessageStatusId)
    : ICommand
{
    public class Handler(IUserMessageRepository userMessageRepository) 
        : CommandHandler<UpdateUserMessageStatus>
    {
        protected override async Task Handle(UpdateUserMessageStatus command)
        {
            Entity.UserMessage userMessage
                = await userMessageRepository.Get(command.UserMessageId);

            userMessage.SetStatus(command.UserMessageStatusId);

            await userMessageRepository.Update(userMessage);
        }
    }
}
