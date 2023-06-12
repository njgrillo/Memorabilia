﻿namespace Memorabilia.Blazor.Controls;

public partial class EditDomainItem
{
    [Parameter]
    public DomainEditModel Item
    {
        get
        {
            return Model;
        }
        set
        {
            Model = value;
        }
    }

    [Parameter]
    public int MaxAbbreviationLength { get; set; } 
        = 10;

    [Parameter]
    public int MaxNameLength { get; set; } 
        = 100;

    [Parameter]
    public EventCallback OnLoad { get; set; }

    [Parameter]
    public EventCallback<DomainEditModel> OnSave { get; set; }

    protected DomainEditModel Model;

    protected async Task Load()
    {
        if (Model.Id == 0)
            return;

        await OnLoad.InvokeAsync();
    }

    protected async Task Save()
    {
        await OnSave.InvokeAsync(Model);
    }
}
