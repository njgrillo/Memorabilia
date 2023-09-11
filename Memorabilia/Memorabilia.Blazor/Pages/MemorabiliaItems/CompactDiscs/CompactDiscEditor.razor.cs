namespace Memorabilia.Blazor.Pages.MemorabiliaItems.CompactDiscs;

public partial class CompactDiscEditor : MemorabiliaItem<CompactDiscEditModel>
{
    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        Entity.Memorabilia memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        EditModel = new(new CompactDiscModel(memorabilia));
        EditModel.MemorabiliaId = MemorabiliaId;
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveCompactDisc.Command(EditModel));
    }
}
