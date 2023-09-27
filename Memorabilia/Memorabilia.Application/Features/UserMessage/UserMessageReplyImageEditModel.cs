namespace Memorabilia.Application.Features.UserMessage;

public class UserMessageReplyImageEditModel : EditModel
{
	public UserMessageReplyImageEditModel() { }

    public UserMessageReplyImageEditModel(string imageFileName)
    {
        ImageFileName = imageFileName;
    }

    public UserMessageReplyImageEditModel(int id, 
										  string imageFileName,
										  int userMessageReplyId)
	{
		Id = id;
		ImageFileName = imageFileName;
		UserMessageReplyId = userMessageReplyId;
	}

	public UserMessageReplyImageEditModel(Entity.UserMessageReplyImage userMessageReplyImage)
	{
		Id = userMessageReplyImage.Id;
        ImageFileName = userMessageReplyImage.FileName;
        UserMessageReplyId = userMessageReplyImage.UserMessageReplyId;
    }

	public string ImageFileName { get; set; }

	public int UserMessageReplyId { get; set; }
}
