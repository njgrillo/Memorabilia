using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia;

public class SaveMemorabiliaItemViewModel : SaveViewModel
{
    public SaveMemorabiliaItemViewModel() { }

    public SaveMemorabiliaItemViewModel(MemorabiliaItemViewModel viewModel)
    {
        AcquiredDate = viewModel.Acquisition.AcquiredDate;
        AcquiredWithAutograph = viewModel.Acquisition.AcquiredWithAutograph ?? false;
        AcquisitionTypeId = viewModel.Acquisition.AcquisitionTypeId;
        ConditionId = viewModel.ConditionId ?? 0;
        Cost = viewModel.Acquisition.Cost;
        CreateDate = viewModel.CreateDate;
        Denominator = viewModel.Denominator;
        EstimatedValue = viewModel.EstimatedValue;
        Id = viewModel.Id;
        ItemType = ItemType.Find(viewModel.ItemTypeId);
        LastModifiedDate = viewModel.LastModifiedDate;
        Note = viewModel.Note;
        Numerator = viewModel.Numerator;
        PrivacyTypeId = viewModel.PrivacyTypeId;            
        PurchaseTypeId = viewModel.PurchaseTypeId ?? 0;            
        UserId = viewModel.UserId;
    }

    public DateTime? AcquiredDate { get; set; }

    public bool AcquiredWithAutograph { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Acquisition Type is required.")]
    public int AcquisitionTypeId { get; set; } = AcquisitionType.Purchase.Id;

    public bool CanEditItemType => Id == 0;

    public bool CanHaveCost => AcquisitionType.CanHaveCost(AcquisitionType.Find(AcquisitionTypeId));

    public int ConditionId { get; set; } = Condition.Pristine.Id;

    public decimal? Cost { get; set; }

    public DateTime CreateDate { get; set; }

    public int? Denominator { get; set; }

    public decimal? EstimatedValue { get; set; }

    public override string ExitNavigationPath => "Memorabilia/Items";

    public string ImageFileName => $"{(!ItemTypeName.IsNullOrEmpty() ? $"{ItemTypeName.Replace(" ", "")}.jpg" : "itemtypes.jpg")}";

    private bool? _isNumbered;
    public bool IsNumbered
    {
        get
        {
            _isNumbered ??= Numerator.HasValue || Denominator.HasValue;

            return _isNumbered ?? false;
        }
        set
        {
            _isNumbered = value;

            if (!_isNumbered ?? false)
            {
                Denominator = null;
                Numerator = null;
            }
        }
    }

    public ItemType ItemType { get; set; }

    public string ItemTypeName => ItemType?.Name;

    public DateTime? LastModifiedDate { get; set; }

    public MemorabiliaItemStep MemorabiliaItemStep => MemorabiliaItemStep.Item;

    public string Note { get; set; }

    public int? Numerator { get; set; }

    public override string PageTitle => $"{(Id > 0 ? EditModeType.Update.Name : EditModeType.Add.Name)} {(ItemType?.Id > 0 ? ItemTypeName : "Memorabilia")}";

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Privacy Type is required.")]
    public int PrivacyTypeId { get; set; } = PrivacyType.Public.Id;

    public int PurchaseTypeId { get; set; }

    public int UserId { get; set; }
}
