namespace Memorabilia.Application.Features.UserMessage;

public class UserMessagesModel : Model
{
    public UserMessagesModel() { }

    public UserMessagesModel(Entity.UserMessage[] messages)
    {
        Messages = messages.Select(message => new UserMessageModel(message))
                           .ToList();
    }

    public UserMessagesModel(Entity.UserMessage[] messages, PageInfoResult pageInfo)
    {
        Messages = messages.Select(message => new UserMessageModel(message))
                           .ToList();

        PageInfo = pageInfo;
    }

    public List<UserMessageModel> Messages { get; set; }
        = new();
}
