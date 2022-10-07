namespace Memorabilia.MauiBlazor.Pages.Project
{
	public partial class Projects : ComponentBase
	{
        protected int UserId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var userId = await SecureStorage.Default.GetAsync("UserId");

            UserId = userId.ToInt32();
        }
    }
}
