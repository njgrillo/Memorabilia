namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class UserMessageImages
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public EventCallback ImageRemoved { get; set; }

    [Parameter]
    public List<UserMessageReplyImageEditModel> Images { get; set; }
        = new();

    public async Task OnImageRemoved(string imageFileName)
    {
        Images.RemoveAll(image => image.ImageFileName == imageFileName);

        await ImageRemoved.InvokeAsync();
    }
}
