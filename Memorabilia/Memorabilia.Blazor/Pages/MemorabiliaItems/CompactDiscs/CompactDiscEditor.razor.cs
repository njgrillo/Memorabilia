namespace Memorabilia.Blazor.Pages.MemorabiliaItems.CompactDiscs;

public partial class CompactDiscEditor : MemorabiliaItem<CompactDiscEditModel>
{
    protected async Task OnLoad()
    {
        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        EditModel = new(new CompactDiscModel(memorabilia));
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveCompactDisc.Command(EditModel));
    }
}
