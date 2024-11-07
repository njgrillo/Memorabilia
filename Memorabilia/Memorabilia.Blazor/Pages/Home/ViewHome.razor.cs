namespace Memorabilia.Blazor.Pages.Home;

public partial class ViewHome
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public ILogger<ViewHome> Logger { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    protected string BackgroundImageText { get; set; }
        = "Add Background Image";

    protected string BackgroundStyle { get; set; }

    protected bool CanEditBackgroundImage
        => ApplicationStateService.CurrentUser?.Id > 0;

    protected bool HasBackgroundImage { get; set; }

    protected HomeModel Model { get; set; }
        = new();

    protected override async Task OnInitializedAsync()
    {
        Model = await Mediator.Send(new GetHome());
        HasBackgroundImage = !string.IsNullOrWhiteSpace(ApplicationStateService.CurrentUser?.UserSettings?.HomeBackgroundImageFileName);

        if (!HasBackgroundImage)
            return;

        SetBackgroundImage(ApplicationStateService.CurrentUser.UserSettings.HomeBackgroundImageFileName);
    }

    private async Task LoadFile(InputFileChangeEventArgs e)
    {
        try
        {
            string imageFileName = await ImageService.LoadFile(e.File, Enum.ImageRootType.User);

            SetBackgroundImage(imageFileName);

            await Mediator.Send(new SaveHomeBackgroundImage(imageFileName));            
        }
        catch (Exception ex)
        {
            Logger.LogError("File: {Filename} Error: {Error}", e.File.Name, ex.Message);
        }
    }

    private async Task RemoveBackgroundImage()
    {
        await Mediator.Send(new SaveHomeBackgroundImage(null));

        BackgroundStyle = string.Empty;
        BackgroundImageText = "Add Background Image";

        HasBackgroundImage = false;
    }

    private void SetBackgroundImage(string imageFileName)
    {
        string imageData = ImageService.GetUserImageData(imageFileName, ApplicationStateService.CurrentUser.Id);

        BackgroundStyle = $"background-image: url('{imageData}');";
        BackgroundImageText = "Change Background Image";

        HasBackgroundImage = true;
    }
}
