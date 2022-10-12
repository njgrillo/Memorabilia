#nullable disable

namespace Memorabilia.Blazor.Pages.Autograph.Inscriptions;

public partial class InscriptionsEditor : ComponentBase
{
    [Parameter]
    public int AutographId { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    private bool _canAddInscription = true;
    private bool _canEditInscriptionType = true;
    private bool _canUpdateInscription;
    private SaveInscriptionsViewModel _inscriptionsViewModel = new ();
    private SaveInscriptionViewModel _viewModel = new ();

    protected async Task OnLoad()
    {
        var autograph = await QueryRouter.Send(new GetAutograph.Query(AutographId)).ConfigureAwait(false);

        _inscriptionsViewModel = new SaveInscriptionsViewModel(autograph.Inscriptions, 
                                                               autograph.ItemTypeId, 
                                                               autograph.MemorabiliaId,
                                                               autograph.Id);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveInscriptions.Command(_inscriptionsViewModel)).ConfigureAwait(false);

        _inscriptionsViewModel.ContinueNavigationPath = $"Autographs/Authentications/{EditModeType.Update.Name}/{AutographId}";
    }

    private void AddInscription()
    {
        _inscriptionsViewModel.Inscriptions.Add(_viewModel);
        _viewModel = new SaveInscriptionViewModel();
    }

    private void Edit(SaveInscriptionViewModel inscription)
    {
        _viewModel.InscriptionTypeId = inscription.InscriptionTypeId;
        _viewModel.InscriptionText = inscription.InscriptionText;

        _canAddInscription = false;
        _canEditInscriptionType = false;
        _canUpdateInscription = true;
    }

    private void Remove(int inscriptionTypeId, string inscriptionText)
    {
        var inscription = _inscriptionsViewModel.Inscriptions.Single(inscription => inscription.InscriptionTypeId == inscriptionTypeId &&
                                                                                    inscription.InscriptionText == inscriptionText);

        inscription.IsDeleted = true;
    }

    private void UpdateInscription()
    {
        var inscription = _inscriptionsViewModel.Inscriptions.Single(inscription => inscription.InscriptionTypeId == _viewModel.InscriptionTypeId);

        inscription.InscriptionText = _viewModel.InscriptionText;

        _viewModel = new SaveInscriptionViewModel();

        _canAddInscription = true;
        _canEditInscriptionType = true;
        _canUpdateInscription = false;
    }
}
