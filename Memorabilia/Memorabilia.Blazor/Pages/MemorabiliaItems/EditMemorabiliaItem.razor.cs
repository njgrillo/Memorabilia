﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class EditMemorabiliaItem<TItem> where TItem 
    : MemorabiliaItemEditModel
{
    [Parameter]
    public RenderFragment AdditionalContent { get; set; }

    [Parameter]
    public bool CanFilterPersonBySport { get; set; }
        = true;

    [Parameter]
    public bool CanToggleMultiTeamSelector { get; set; } 
        = true;   

    [Parameter]
    public bool DisplayItemTypeBrand { get; set; } 
        = true;

    [Parameter]
    public bool DisplayItemTypeGameStyle { get; set; } 
        = true;

    [Parameter]
    public bool DisplayItemTypeLevel { get; set; } 
        = true;

    [Parameter]
    public bool DisplayItemTypeSize { get; set; } 
        = true;

    [Parameter]
    public bool DisplayMultiPersonSelector { get; set; }

    [Parameter]
    public bool DisplayMultiSportSelector { get; set; }

    [Parameter]
    public bool DisplayMultiTeamSelector { get; set; }

    [Parameter]
    public bool DisplaySinglePersonSelector { get; set; }

    [Parameter]
    public bool DisplaySingleSportSelector { get; set; }

    [Parameter]
    public bool DisplaySingleTeamSelector { get; set; } 

    [Parameter]
    public string GameDateDisplayText { get; set; } 
        = "Game Date";

    [Parameter]
    public string GameStyleTypeDisplayText { get; set; } 
        = "Game Style";

    [Parameter]
    public TItem Model { get; set; }
}
