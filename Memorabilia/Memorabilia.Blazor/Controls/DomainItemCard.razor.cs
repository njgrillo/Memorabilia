#nullable disable

namespace Memorabilia.Blazor.Controls
{
    public partial class DomainItemCard : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Description { get; set; }

        [Parameter]
        public string ImagePath { get; set; }

        [Parameter]
        public string Page { get; set; }

        [Parameter]
        public string Title { get; set; }

        protected void OnClick()
        {
            NavigationManager.NavigateTo(Page);
        }
    }
}
