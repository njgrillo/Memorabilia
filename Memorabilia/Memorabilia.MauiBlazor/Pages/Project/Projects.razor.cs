using Microsoft.AspNetCore.Components;

namespace Memorabilia.MauiBlazor.Pages.Project
{
	public partial class Projects : ComponentBase
	{
        [Parameter]
        public RenderFragment Content { get; set; }
    }
}
