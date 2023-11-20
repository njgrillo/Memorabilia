namespace Memorabilia.Blazor.Pages.UserMessage;

public partial class ReplyUserMessage
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public UserMessageReplyValidator Validator { get; set; }

    [Parameter]
    public string EncryptUserMessageReplyId { get; set; }

    protected bool CanAttach { get; set; }
        = true;

    protected UserMessageEditModel EditModel { get; set; }
        = new();

    protected int UserMessageReplyId { get; set; }

    protected UserMessageReplyModel UserMessageReplyModel { get; set; }

    protected Alert[] ValidationResultAlerts
        => EditModel.ValidationResult.HasErrors()
            ? EditModel.ValidationResult.Errors.Select(error => new Alert(error.ErrorMessage, Severity.Error)).ToArray()
            : [];

    protected override async Task OnInitializedAsync()
    {
        UserMessageReplyId = DataProtectorService.DecryptId(EncryptUserMessageReplyId);

        Entity.UserMessageReply userMessageReply
            = await Mediator.Send(new GetUserMessageReply(UserMessageReplyId));

        UserMessageReplyModel
            = new UserMessageReplyModel(userMessageReply);

        Entity.UserMessage userMessage
            = await Mediator.Send(new GetUserMessage(userMessageReply.UserMessageId));        

        EditModel = new(userMessage, ApplicationStateService.CurrentUser, UserMessageReplyModel.SenderUser);

        CanAttach = EditModel.UserMessageReply.Images.Count < 3;
    }

    protected async Task AddImages()
    {
        var parameters = new DialogParameters
        {
            ["MaximumImagesAllowed"] = 3 - EditModel.UserMessageReply.Images.Count
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<UserMessageImageDialog>(string.Empty,
                                                                parameters,
                                                                options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var files = (List<ImageEditModel>)result.Data;

        List<UserMessageReplyImageEditModel> images = [];

        foreach (ImageEditModel image in files)
        {
            images.Add(new UserMessageReplyImageEditModel(image.FileName));
        }

        EditModel.UserMessageReply.Images = images;

        CanAttach = EditModel.UserMessageReply.Images.Count < 3;
    }

    protected void OnImageRemoved()
    {
        CanAttach = EditModel.UserMessageReply.Images.Count < 3;
    }

    protected async Task Send()
    {
        var command = new AddUserMessageReply.Command(EditModel.UserMessageReply);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await Mediator.Send(command);

        Snackbar.Add("Message sent successfully!", Severity.Success);

        NavigationManager.NavigateTo(NavigationPath.Messages);
    }    
}
