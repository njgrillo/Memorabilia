using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Autograph.Inscriptions;

public partial class EditInscriptions
    : AutographItem<InscriptionEditModel>
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public InscriptionValidator Validator { get; set; }

    [Parameter]
    public string EncryptAutographId { get; set; }

    protected InscriptionsEditModel EditModel 
        = new();

    private string _continueNavigationPath;

    protected override async Task OnInitializedAsync()
    {
        AutographId = DataProtectorService.DecryptId(EncryptAutographId);   

        var autograph = new AutographModel(await Mediator.Send(new GetAutograph(AutographId)));

        EditModel = new InscriptionsEditModel(autograph.Inscriptions,
                                              autograph.ItemTypeId,
                                              autograph.UserId,
                                              autograph.MemorabiliaId,
                                              autograph.Id,
                                              autograph.MemorabiliaImageNames,
                                              autograph.PersonId);

        IsLoaded = true;
    }

    protected async Task Save()
    {
        await Mediator.Send(new SaveInscriptions.Command(EditModel));

        _continueNavigationPath
            = $"{NavigationPath.Authentications}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(EditModel.AutographId)}";
    }

    private void Add()
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

        EditMode = EditModeType.Update;
    }

    private void OnSuggestedInscriptionSelected(SuggestedInscriptionModel inscription)
    {
        Model.InscriptionTypeId = inscription.InscriptionType.Id;
        Model.InscriptionText = inscription.Text;
    }

    private void Update()
    {
        Model.ValidationResult = Validator.Validate(Model);

        if (!Model.ValidationResult.IsValid)
            return;

        InscriptionEditModel inscription 
            = EditModel.Inscriptions
                       .Single(inscription => inscription.InscriptionTypeId == Model.InscriptionTypeId);

        inscription.InscriptionText = Model.InscriptionText;

        Model = new();

        EditMode = EditModeType.Add;
    }
}
