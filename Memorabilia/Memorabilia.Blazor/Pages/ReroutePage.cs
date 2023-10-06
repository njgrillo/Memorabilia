﻿namespace Memorabilia.Blazor.Pages;

public abstract class ReroutePage : ComponentBase
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    protected async Task ShowMembershipDialog()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Large,
            FullWidth = true,
            DisableBackdropClick = true
        };

        string dialogTitle
            = ApplicationStateService.CurrentUser != null
                ? "Upgrade Membership"
                : string.Empty;

        var dialog = DialogService.Show<RegisterLoginMembershipDialog>(dialogTitle, new DialogParameters(), options);
        var result = await dialog.Result;
    }
}
