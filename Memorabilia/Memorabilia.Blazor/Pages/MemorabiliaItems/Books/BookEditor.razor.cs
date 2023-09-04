﻿namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Books;

public partial class BookEditor 
    : MemorabiliaItem<BookEditModel>
{
    [Inject]
    public BookValidator Validator { get; set; }

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        EditModel = new(new BookModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId))));
    }

    protected async Task OnSave()
    {
        var command = new SaveBook.Command(EditModel);

        EditModel.ValidationResult = Validator.Validate(command);

        if (!EditModel.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        EditModel.ContinueNavigationPath = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}";
    }
}
