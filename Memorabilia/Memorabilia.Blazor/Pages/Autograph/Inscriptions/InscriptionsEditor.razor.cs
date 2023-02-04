namespace Memorabilia.Blazor.Pages.Autograph.Inscriptions;

public partial class InscriptionsEditor : AutographItem<SaveInscriptionViewModel>
{
    [Inject]
    public InscriptionValidator Validator { get; set; }

    [Parameter]
    public string UploadPath { get; set; }

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
                                                               autograph.Id,
                                                               autograph.MemorabiliaImageNames,
                                                               autograph.PersonId);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveInscriptions.Command(_inscriptionsViewModel));
    }

    private void AddInscription()
    {
        ViewModel.ValidationResult = Validator.Validate(ViewModel);

        if (!ViewModel.ValidationResult.IsValid)
            return;

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

    private void OnSuggestedInscriptionSelected(SuggestedInscriptionViewModel inscription)
    {
        ViewModel.InscriptionTypeId = inscription.InscriptionType.Id;
        ViewModel.InscriptionText = inscription.Text;
    }

    private void UpdateInscription()
    {
        ViewModel.ValidationResult = Validator.Validate(ViewModel);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        var inscription = _inscriptionsViewModel.Inscriptions
                                                .Single(inscription => inscription.InscriptionTypeId == ViewModel.InscriptionTypeId);

        inscription.InscriptionText = ViewModel.InscriptionText;

        ViewModel = new SaveInscriptionViewModel();        

        _canAddInscription = true;
        _canEditInscriptionType = true;
        _canUpdateInscription = false;
    }
}
