namespace Memorabilia.Blazor.Pages.Admin.TransactionTypes;

public partial class ViewTransactionTypes
    : ViewDomainItem<TransactionTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveTransactionType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new TransactionTypesModel(await Mediator.Send(new GetTransactionTypes()));
    }
}
