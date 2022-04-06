using Microsoft.AspNetCore.Components;

namespace Memorabilia.Web.Controls
{
    public partial class PageImage : ComponentBase
    {
        [Parameter]
        public string ImagePath { get; set; }   
    }
}
