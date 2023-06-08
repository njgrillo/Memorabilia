namespace Memorabilia.Blazor.Pages.Autograph.Inscriptions;

public partial class InscriptionsEditor : AutographItem<InscriptionEditModel>
{
    [Inject]
    public InscriptionValidator Validator { get; set; }

    [Parameter]
    public string UploadPath { get; set; }

    private bool _canAddInscription = true;
    private bool _canEditInscriptionType = true;
    private bool _canUpdateInscription;
    private InscriptionsEditModel _InscriptionsModel = new ();

    protected async Task OnLoad()
    {
        var autograph = new AutographModel(await QueryRouter.Send(new GetAutograph(AutographId)));

        _InscriptionsModel = new InscriptionsEditModel(autograph.Inscriptions, 
                                                       autograph.ItemTypeId, 
                                                       autograph.UserId,
                                                       autograph.MemorabiliaId,
                                                       autograph.Id,
                                                       autograph.MemorabiliaImageNames,
                                                       autograph.PersonId);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveInscriptions.Command(_InscriptionsModel));
    }

    private void AddInscription()
    {
        ViewModel.ValidationResult = Validator.Validate(ViewModel);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        _InscriptionsModel.Inscriptions.Add(ViewModel);

        ViewModel = new InscriptionEditModel();
    }

    private void Edit(InscriptionEditModel inscription)
    {
        ViewModel.InscriptionTypeId = inscription.InscriptionTypeId;
        ViewModel.InscriptionText = inscription.InscriptionText;

        _canAddInscription = false;
        _canEditInscriptionType = false;
        _canUpdateInscription = true;
    }

    private void OnSuggestedInscriptionSelected(SuggestedInscriptionModel inscription)
    {
        ViewModel.InscriptionTypeId = inscription.InscriptionType.Id;
        ViewModel.InscriptionText = inscription.Text;
    }

    private void UpdateInscription()
    {
        ViewModel.ValidationResult = Validator.Validate(ViewModel);

        if (!ViewModel.ValidationResult.IsValid)
            return;

        var inscription = _InscriptionsModel.Inscriptions
                                                .Single(inscription => inscription.InscriptionTypeId == ViewModel.InscriptionTypeId);

        inscription.InscriptionText = ViewModel.InscriptionText;

        ViewModel = new InscriptionEditModel();        

        _canAddInscription = true;
        _canEditInscriptionType = true;
        _canUpdateInscription = false;
    }
}
