#nullable disable

namespace Memorabilia.Blazor.Pages.Autograph.Inscriptions;

public partial class InscriptionsEditor : AutographItem<SaveInscriptionViewModel>
{
    private bool _canAddInscription = true;
    private bool _canEditInscriptionType = true;
    private bool _canUpdateInscription;
    private SaveInscriptionsViewModel _inscriptionsViewModel = new ();

    protected async Task OnLoad()
    {
        var autograph = await QueryRouter.Send(new GetAutograph.Query(AutographId));

        _inscriptionsViewModel = new SaveInscriptionsViewModel(autograph.Inscriptions, 
                                                               autograph.ItemTypeId, 
                                                               autograph.MemorabiliaId,
                                                               autograph.Id);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveInscriptions.Command(_inscriptionsViewModel));

        _inscriptionsViewModel.ContinueNavigationPath = $"Autographs/Authentications/{EditModeType.Update.Name}/{AutographId}";
    }

    private void AddInscription()
    {
        _inscriptionsViewModel.Inscriptions.Add(ViewModel);

        ViewModel = new SaveInscriptionViewModel();
    }

    private void Edit(SaveInscriptionViewModel inscription)
    {
        ViewModel.InscriptionTypeId = inscription.InscriptionTypeId;
        ViewModel.InscriptionText = inscription.InscriptionText;

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
        var inscription = _inscriptionsViewModel.Inscriptions.Single(inscription => inscription.InscriptionTypeId == ViewModel.InscriptionTypeId);

        inscription.InscriptionText = ViewModel.InscriptionText;

        ViewModel = new SaveInscriptionViewModel();

        _canAddInscription = true;
        _canEditInscriptionType = true;
        _canUpdateInscription = false;
    }
}
