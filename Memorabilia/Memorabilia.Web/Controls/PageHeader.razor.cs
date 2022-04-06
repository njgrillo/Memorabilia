using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls
{
    public partial class PageHeader : ComponentBase
    {
        [Parameter]
        public string PageTitle { get; set; }
    }
}
