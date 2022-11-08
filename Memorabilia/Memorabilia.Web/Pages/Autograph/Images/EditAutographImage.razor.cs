namespace Memorabilia.Web.Pages.Autograph.Images;

public partial class EditAutographImage : AutographItem
{
    protected string UploadPath { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var userId = await LocalStorage.GetAsync<int>("UserId");

        UploadPath = Path.Combine(MemorabiliaImageRootPath, userId.Value.ToString());
    }
}
