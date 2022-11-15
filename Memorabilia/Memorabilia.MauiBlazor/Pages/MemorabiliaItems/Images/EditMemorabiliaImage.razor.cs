namespace Memorabilia.MauiBlazor.Pages.MemorabiliaItems.Images;

public partial class EditMemorabiliaImage : DesktopPage
{
    [Parameter]
    public int MemorabiliaId { get; set; }

    protected string UploadPath { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var userId = await SecureStorage.Default.GetAsync("UserId");

        UploadPath = Path.Combine(MemorabiliaImageRootPath, userId);
    }
}
