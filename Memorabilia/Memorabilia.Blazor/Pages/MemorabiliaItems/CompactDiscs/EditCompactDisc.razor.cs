namespace Memorabilia.Blazor.Pages.MemorabiliaItems.CompactDiscs;

public partial class EditCompactDisc
    : MemorabiliaItem<CompactDiscEditModel>
{
    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        Entity.Memorabilia memorabilia = await Mediator.Send(new GetMemorabiliaItem(MemorabiliaId));

        EditModel = new(new CompactDiscModel(memorabilia));
        EditModel.MemorabiliaId = MemorabiliaId;
    }

    protected async Task OnSave()
    {
        await Mediator.Send(new SaveCompactDisc.Command(EditModel));
    }
}
