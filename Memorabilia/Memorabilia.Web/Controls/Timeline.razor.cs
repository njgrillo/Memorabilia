﻿using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Memorabilia.Web.Controls
{
    public partial class Timeline : ComponentBase
    {
        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public TimelineOrientation Orientation { get; set; } = TimelineOrientation.Horizontal;

        [Parameter]
        public TimelinePosition Position { get; set; } = TimelinePosition.Top;        
    }
}
