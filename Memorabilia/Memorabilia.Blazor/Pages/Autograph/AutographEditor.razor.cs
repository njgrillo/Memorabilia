namespace Memorabilia.Blazor.Pages.Autograph;

public partial class AutographEditor 
    : AutographItem<AutographEditModel>
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public AutographValidator Validator { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    private bool _displayAcquisitionDetails
        = true;

    protected override async Task OnInitializedAsync()
    {
        var model = new MemorabiliaModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId)));

        if (!model.Autographs.Any() || AutographId <= 0)
        {
            Model = new AutographEditModel(model);
            IsLoaded = true;
            return;
        }

        GetModel(model);

        IsLoaded = true;
    }

    protected async Task OnSave()
    {
        var command = new SaveAutograph.Command(Model);

        Model.ValidationResult = Validator.Validate(command);

        if (!Model.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Model.ContinueNavigationPath = $"Autographs/Inscriptions/{EditModeType.Update.Name}/{command.Id}";
    }

    private void GetModel(MemorabiliaModel model)
    {
        AutographModel autograph 
            = model.Autographs.SingleOrDefault(autograph => autograph.Id == AutographId);

        if (autograph == null)
        {
            Model = new AutographEditModel(model);
            return;
        }

        Model = new AutographEditModel(autograph);

        _displayAcquisitionDetails = Model.AcquisitionTypeId > 0;
    }

    private void OnAcquisitionTypeChange(int acquisitionTypeId)
    {
        Model.AcquisitionTypeId = acquisitionTypeId;

        var acquisitionType = AcquisitionType.Find(acquisitionTypeId);

        if (!acquisitionType.CanHaveCost())
            Model.Cost = null;

        if (!acquisitionType.CanHavePurchaseType())
            Model.PurchaseTypeId = 0;

        if (!acquisitionType.CanHaveSendAndReceiveDates())
        {
            Model.ReceivedDate = null;
            Model.SentDate = null;
        }
    }

    private void OnImportAcquisition()
    {
        Model.AcquisitionTypeId = Model.MemorabiliaAcquisitionTypeId;
        Model.AcquiredDate = Model.MemorabiliaAcquiredDate;
        Model.Cost = Model.MemorabiliaCost;
        Model.PurchaseTypeId = Model.MemorabiliaPurchaseTypeId ?? 0;
    }

    private void OnImportEstimatedValue()
    {
        Model.EstimatedValue = Model.MemorabiliaEstimatedValue;
    }
}
