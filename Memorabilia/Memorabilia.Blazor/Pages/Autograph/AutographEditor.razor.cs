namespace Memorabilia.Blazor.Pages.Autograph;

public partial class AutographEditor 
    : AutographItem<AutographEditModel>
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public AutographValidator Validator { get; set; }

    [Parameter]
    public string EncryptAutographId { get; set; }

    [Parameter]
    public string EncryptMemorabiliaId { get; set; }

    protected int MemorabiliaId;

    private bool _displayAcquisitionDetails
        = true;

    protected override async Task OnInitializedAsync()
    {
        MemorabiliaId = DataProtectorService.DecryptId(EncryptMemorabiliaId);

        AutographId = EncryptAutographId.IsNullOrEmpty()
            ? 0
            : DataProtectorService.DecryptId(EncryptAutographId);

        var model = new MemorabiliaModel(await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId)));

        if (!model.Autographs.Any() || AutographId <= 0)
        {
            Model = new AutographEditModel(model)
            {
                BackNavigationPath
                    = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}"
            };

            IsLoaded = true;

            return;
        }

        GetModel(model);

        IsLoaded = true;
    }

    protected async Task Save()
    {
        var command = new SaveAutograph.Command(Model);

        Model.ValidationResult = Validator.Validate(command);

        if (!Model.ValidationResult.IsValid)
            return;

        await CommandRouter.Send(command);

        Model.Id = command.Id;

        Model.ContinueNavigationPath 
            = $"Autographs/Inscriptions/Edit/{DataProtectorService.EncryptId(Model.Id)}";
    }

    private void GetModel(MemorabiliaModel model)
    {
        AutographModel autograph 
            = model.Autographs.SingleOrDefault(autograph => autograph.Id == AutographId);

        if (autograph == null)
        {
            Model = new AutographEditModel(model)
            {
                BackNavigationPath
                    = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}"
            };

            return;
        }

        Model = new AutographEditModel(autograph)
        {
            BackNavigationPath
                = $"Memorabilia/Image/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(MemorabiliaId)}"
        };

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
