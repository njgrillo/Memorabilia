﻿namespace Memorabilia.Blazor.Pages.Admin.Positions;

public partial class PositionEditor 
    : EditItem<PositionEditModel, PositionModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePosition(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new PositionEditModel(new PositionModel(await QueryRouter.Send(new GetPosition(Id))));
    }
}
