#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.InscriptionTypes;

public partial class ViewInscriptionTypes : ViewDomainItem<InscriptionTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveInscriptionType.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetInscriptionTypes.Query()).ConfigureAwait(false);
    }
}
