namespace Memorabilia.Blazor.Pages.Autograph.Inscriptions;

public partial class InscriptionsEditor 
    : AutographItem<InscriptionEditModel>
{
    [Inject]
    public InscriptionValidator Validator { get; set; }

    protected InscriptionsEditModel EditModel 
        = new();

    private bool _canAddInscription 
        = true;

    private bool _canEditInscriptionType 
        = true;

    private bool _canUpdateInscription;    

    protected override async Task OnInitializedAsync()
    {
        var autograph = new AutographModel(await QueryRouter.Send(new GetAutograph(AutographId)));

        EditModel = new InscriptionsEditModel(autograph.Inscriptions, 
                                              autograph.ItemTypeId, 
                                              autograph.UserId,
                                              autograph.MemorabiliaId,
                                              autograph.Id,
                                              autograph.MemorabiliaImageNames,
                                              autograph.PersonId);
    }

    protected async Task OnSave()
    {
        await CommandRouter.Send(new SaveInscriptions.Command(EditModel));
    }

    private void AddInscription()
    {
        Model.ValidationResult = Validator.Validate(Model);

        if (!Model.ValidationResult.IsValid)
            return;

        EditModel.Inscriptions.Add(Model);

        Model = new();
    }

    private void Edit(InscriptionEditModel inscription)
    {
        Model.InscriptionTypeId = inscription.InscriptionTypeId;
        Model.InscriptionText = inscription.InscriptionText;

        _canAddInscription = false;
        _canEditInscriptionType = false;
        _canUpdateInscription = true;
    }

    private void OnSuggestedInscriptionSelected(SuggestedInscriptionModel inscription)
    {
        Model.InscriptionTypeId = inscription.InscriptionType.Id;
        Model.InscriptionText = inscription.Text;
    }

    private void UpdateInscription()
    {
        Model.ValidationResult = Validator.Validate(Model);

        if (!Model.ValidationResult.IsValid)
            return;

        InscriptionEditModel inscription 
            = EditModel.Inscriptions
                       .Single(inscription => inscription.InscriptionTypeId == Model.InscriptionTypeId);

        inscription.InscriptionText = Model.InscriptionText;

        Model = new();        

        _canAddInscription = true;
        _canEditInscriptionType = true;
        _canUpdateInscription = false;
    }
}
