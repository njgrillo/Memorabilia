namespace Memorabilia.Application.Features.UserMessage;

public class UserMessageReplyImageEditModel : EditModel
{
	public UserMessageReplyImageEditModel() { }

	public UserMessageReplyImageEditModel(Entity.UserMessageReplyImage userMessageReplyImage)
	{
		Id = userMessageReplyImage.Id;
		ImageData = userMessageReplyImage.ImageData;
        UserMessageReplyId = userMessageReplyImage.UserMessageReplyId;
    }

	public byte[] ImageData { get; set; }

	public int UserMessageReplyId { get; set; }
}
